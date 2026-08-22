using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rd;
    [SerializeField]private float bulletSpeed;             //biến lưu tốc độ di chuyển bullet của player;
    [SerializeField]private int damage = 1;                //biến lưu damage khi đạn va chạm object;
    [SerializeField]private GameObject deathEnemyParticle; //biến lưu particle khi va chạm chết;
    [SerializeField]private GameObject bulletParticle;     //biến lưu particle khi bullet va chạm object;
    [SerializeField]private PlayerController player;       //biến lưu tham chiếu đến 1 object của PlayerController;
    [SerializeField]private AudioClip bulletSound;         //biến lưu clip âm thanh
    private void Awake()
    {
        player = FindAnyObjectByType<PlayerController>();
        rd = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {   
        if(player.transform.localScale.x < 0)
        {
            bulletSpeed = -bulletSpeed;
        }
    }
    private void Update()
    {
        MovementBullet(); // hàm di chuyển đạn của Player;
    }
    private void MovementBullet()
    {
        rd.linearVelocity = new Vector2 (bulletSpeed, rd.linearVelocity.y);
        Destroy(gameObject,3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {    //Debug.Log("Bullet chạm: " + collision.name);
        if(collision.name == "Enemy")
        {   
        IDamage tagetEnemy = collision.GetComponentInParent<IDamage>(); //dùng interface
            if(tagetEnemy != null)
            {   
            GameObject deathEnemyParticle2 = Instantiate(deathEnemyParticle,collision.transform.position,collision.transform.rotation);
            tagetEnemy.TakeDamage(damage);
            AudioSource.PlayClipAtPoint(bulletSound,transform.position);
            //Destroy(collision.gameObject);
            Destroy(deathEnemyParticle2,2f);
            GameObject bulletParticle2 =  Instantiate(bulletParticle,transform.position,transform.rotation);
            Destroy(gameObject);
            Destroy(bulletParticle2,2f);
            return;
            }
        }
        if(collision.CompareTag("Ground"))
        {  Debug.Log("TRÚNG GROUND");
            GameObject bulletParticle2 =  Instantiate(bulletParticle,transform.position,transform.rotation);
            Destroy(bulletParticle2,2f);
            Destroy(gameObject);
            return;
        }
    }
}
