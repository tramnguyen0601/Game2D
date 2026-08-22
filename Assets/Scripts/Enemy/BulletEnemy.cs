using UnityEngine;
public class BulletEnemy : MonoBehaviour
{
    [SerializeField]private float bulletEnemySpeed = 1f; //biến lưu tốc bộ bắn của đạn
    [SerializeField]private int damage = 1;              //biến lưu số live bị trừ khi va chạm Player
    //private PlayerController playerController;         // biến lưu tham chiếu đến 1 object của PlayerController
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerController = FindAnyObjectByType<PlayerController>();
    }
    private void Start()
    {
        //-----ENEMY CÓ THỂ BẮN NHIỀU HƯỚNG, THẲNG/CHÉO TÙY VÀO VỊ TRÍ CỦA PLAYER-----//
        //rb = GetComponent<Rigidbody2D>();
        // if(playerController != null)
        // {  
        //    Vector2 direction = (playerController.transform.position - transform.position).normalized;
        //    //Debug.Log("Direction = " + direction);
        //    rb.linearVelocity = direction * bulletEnemySpeed;
        //    //Debug.Log("Velocity = " + rb.linearVelocity);
        // }
        
    }
    public void SetDirection(float direction)
    {
        rb.linearVelocity = new Vector2(direction * bulletEnemySpeed,0f);
        Destroy(gameObject,5f);
    }
   private void OnTriggerEnter2D(Collider2D collision)
   {
        if(collision.CompareTag("Player"))
        {
            //HeartManager.instance.TakeDamage(damage);
            IDamage taget = collision.GetComponent<IDamage>();
            if(taget != null)
            {
               taget.TakeDamage(damage);
               Destroy(gameObject);
               return;
            }
        }
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
            return;
        }
   }
}

