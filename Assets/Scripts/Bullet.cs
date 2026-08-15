using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rd;
    public float bulletSpeed;
    public int score;
    public GameObject deathEnemyParticle;
    public GameObject bulletParticle;
    public PlayerController player;
    public AudioClip bulletSound;
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
            GameObject deathEnemyParticle2 = Instantiate(deathEnemyParticle,collision.transform.position,collision.transform.rotation);
            ScoreManager.instance.AddPoints(score);
            AudioSource.PlayClipAtPoint(bulletSound,transform.position);
            Destroy(collision.gameObject);
            Destroy(deathEnemyParticle2,2f);
            GameObject bulletParticle2 =  Instantiate(bulletParticle,transform.position,transform.rotation);
            Destroy(gameObject);
            Destroy(bulletParticle2,2f);
        }
        if(collision.CompareTag("Ground"))
        {  Debug.Log("TRÚNG GROUND");
            Destroy(gameObject);
            return;
        }
        
        
        
    }
}
