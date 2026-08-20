using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour,IDamage
{   
    //----- CÁC BIẾN LƯU XỬ LÝ DI CHUYỂN CỦA ENEMY -----//
    [SerializeField] private float moveSpeed;          //biến lưu tốc độ di chuyển của Enemy;
    [SerializeField] private bool isGrounded;          //biến kiểm tra có tiếp xúc Ground hay không;
    [SerializeField] private Transform groundCheck;    //có position, rotation, size;
    [SerializeField] private bool notGrounded;         //biến kiểm tra vượt biên Ground;
    [SerializeField] private Transform notgroundCheck; //có position, rotation, size;
    [SerializeField] private float checkgroundRadius; //kiểm tra bán kính chân Enemy với Ground;
    [SerializeField] private LayerMask groundLayer;   //add layer Ground;       
    [SerializeField] private bool moveRight;          //biến kiểm tra khi di chuyển phải thì như nào & ngược lại;
    //public bool MoveRight => moveRight;             //biến cho phép class khác đọc được
    public bool MoveRight
    {
        get
        {
            return moveRight;
        }
    }
    private Rigidbody2D rb;

    //----- HỆ THỐNG BẮN CỦA ENEMY -----//
    [SerializeField] private GameObject bulletEnemy;   //biến lưu prefab đạn của Enemy;
    [SerializeField] private Transform firePoint;      //biến lưu vị trí đạn phát ra của Enemy;
    [SerializeField] private GameObject gunEnemy;      //biến lưu ẩn/hiện súng;
    [SerializeField]private bool playerInRange = false;//biến kiểm tra Player có nằm trong vùng bắn của Enemy không; Encapsulation
    private float nextCurrentTime;

    //----- THỜI GIAN CHỜ GIỮA 2 LẦN BẮN/VA CHẠM GROUND ĐỔI HƯỚNG CỦA ENEMY (COOLDOWN) -----//
    [SerializeField] private float waitingTime = 2f;
    private float nextTime;

    private void Awake()//Hàm khởi tạo lấy các Component cần
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        gunEnemy.SetActive(false); //ẩn cây súng;
        
    }   
    private void Update()
    {
        CheckGround();// hàm kiểm tra ground và ngoài ground
        CheckShoot(); // hàm kiểm tra điều kiện bắn -> bắn
        
    }
    private void FixedUpdate()
    {
         Move();
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkgroundRadius,groundLayer);
        notGrounded = Physics2D.OverlapCircle(notgroundCheck.position,checkgroundRadius,groundLayer);
        if ((isGrounded || !notGrounded) && Time.time >= nextCurrentTime)
        {
            moveRight = !moveRight;
            nextCurrentTime = Time.time + 0.2f;
        }
    }
    private void CheckShoot()
    {
        if(playerInRange && Time.time >= nextTime) //nếu kiểm tra Player đã nằm vùng và Enemy đủ time để bắn đạn thì:
        {
            StartCoroutine(ShowGunEnemy());
            Shoot(); // hàm tạo đạn enemy
            nextTime = Time.time + waitingTime; //thời gian đợi để bắn viên đạn tiếp theo;
        }
    }
    private void Shoot()
    {   
        GameObject newBulletEnemy = Instantiate(bulletEnemy,firePoint.position,firePoint.rotation);
        BulletEnemy bulletE = newBulletEnemy.GetComponent<BulletEnemy>();
        if (moveRight)
        {
            bulletE.SetDirection(1f);
        }
        else
        {
            bulletE.SetDirection(-1f);
        }
    }
    private void Move()
    {
        if (moveRight)//nếu di chuyển sang phải
        {   
            transform.localScale = new Vector3 (-1f,1f,1f);
            rb.linearVelocity= new Vector2(moveSpeed,rb.linearVelocity.y);
        }
        else
        {   transform.localScale = new Vector3 (1f,1f,1f);
            rb.linearVelocity= new Vector2(-moveSpeed,rb.linearVelocity.y);
        }
    }
    private IEnumerator ShowGunEnemy()
    {
        gunEnemy.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        gunEnemy.SetActive(false);
    }
        public void SetPlayerInRange(bool value)//Public API: DetectionZoneEnemy dùng hàm SetPlayerInRange để truy cập được,
    {
        playerInRange = value;
    }
    public void TakeDamage(int damage)
    {
        HeartManager.instance.TakeDamage(-damage);
    }
}
