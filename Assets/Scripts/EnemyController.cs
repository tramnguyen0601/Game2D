using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   public float moveSpeed;
    public bool moveRight;
    public bool isGrounded;
    public Transform groundCheck; //có position, rotation, size
    // ban kinh kiem tra mat dat
    public float checkgroundRadius; // check ban kính chan player & ground
    //xac dinh loai vat the nao la mat dat
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    public bool notGrounded;
    public Transform notgroundCheck; //có position, rotation, size
    
    //check vùng phát hiện Player
    public GameObject bulletEnemy; // tạo bản sao bullet
    public Transform firePoint;
    public GameObject gunEnemy;
    public bool playerInRange = false;// kiểm tra xem player có đagn ở trong phạm vi của Enemy không?
    private float nextTime;
    public float waitingTime = 2f;
    private float nextCurrentTime;
    private SpriteRenderer spriteRender;
    public Vector3 gunPos;
    void Start()
    {
        gunEnemy.SetActive(false); //ẩn cây súng

        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        gunPos = gunEnemy.transform.localPosition;
    }   

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkgroundRadius,groundLayer);
        notGrounded = Physics2D.OverlapCircle(notgroundCheck.position,checkgroundRadius,groundLayer);
        if (isGrounded || !notGrounded && Time.time >= nextCurrentTime)
        {
            moveRight = !moveRight;
            nextCurrentTime = Time.time + 0.2f;
        }
        Move();

        if(playerInRange && Time.time >= nextTime) //nếu kiểm tra player đã nằm vùng và enemy đủ time để bắn đạn thì:
        {
            Debug.Log("ĐỦ ĐIỀU KIỆN VÀO =");
            Debug.Log("BẮN LÚC: " + Time.time);
            StartCoroutine(ShowGunEnemy());
            Shoot(); // hàm tạo đạn enemy
            nextTime = Time.time + waitingTime; //thời gian đơi để bắn viên đạn tiêp theo
            Debug.Log("BẮN tiếp theo: " + nextTime);
        }
        

    }
    void Move()
    {
        if (moveRight)// di chuyển sang phải
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
    void Shoot()
    {   
        //Debug.Log("BẮN =");
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
    
}
