using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float bulletEnemySpeed = 1f;
    //public int penalty = 1;
    private PlayerController playerController;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        //rb = GetComponent<Rigidbody2D>();
        // if(playerController != null)
        // {  //enemy bắn nhiều hướng: tùy vị trí đứng của player khi vào vùng.
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
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //HeartManager.instance.TakeDamge(penalty);
            Destroy(gameObject);
            return;
        }
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
            return;
        }
    }
}
