using UnityEngine;

public class Ladder : MonoBehaviour
{   
    //public PlayerController player;
    public float climbSpeed = 3f;
    public float exitClimbSpeed = 2f;
    public float normalGravity =5f;
    public bool isClimb = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = FindAnyObjectByType<PlayerController>();
    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            playerRb.gravityScale = 0f;
            if (isClimb)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x,climbSpeed);
            }
            else
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x,-climbSpeed);
                
            }
            
        }
    }
    void OnTriggerExit2D(Collider2D collision) // ra ngoài vùng Ladder
    {
        if(collision.name == "Player")
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            playerRb.gravityScale = normalGravity; //trọng lực trở về như cũ
            isClimb = !isClimb;
    
        }
    }

}
