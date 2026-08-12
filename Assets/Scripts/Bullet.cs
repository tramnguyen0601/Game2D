using UnityEditor.Callbacks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rd;
    public float bulletSpeed;
    public int score;
    public GameObject deathEnemyParticle;
    public GameObject bulletParticle;
    public PlayerController player;
    void Start()
    {   
        player = FindAnyObjectByType<PlayerController>();
        rd = GetComponent<Rigidbody2D>();
        if(player.transform.localScale.x < 0)
        {
            bulletSpeed = -bulletSpeed;
        }
    }
    void Update()
    {
        rd.linearVelocity = new Vector2 (bulletSpeed, rd.linearVelocity.y);
        Destroy(gameObject,3f);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {    Debug.Log("Bullet chạm: " + collision.name);
        if(collision.name == "Enemy")
        {   
            Instantiate(deathEnemyParticle,collision.transform.position,collision.transform.rotation);
            ScoreManager.instance.AddPoints(score);
            Destroy(collision.gameObject);
            Instantiate(bulletParticle,transform.position,transform.rotation);
            Destroy(gameObject);
        }
        if(collision.CompareTag("Ground"))
        {  Debug.Log("TRÚNG GROUND");
            Destroy(gameObject);
            return;
        }
        
        
        
    }
}
