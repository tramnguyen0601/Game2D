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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkgroundRadius,groundLayer);
        notGrounded = Physics2D.OverlapCircle(notgroundCheck.position,checkgroundRadius,groundLayer);
        if (isGrounded || !notGrounded)
        {
            moveRight = !moveRight;
        }
        Move();
    }
    void Move()
    {
        if (moveRight)
        {   transform.localScale = new Vector3 (-1f,1f,1f);
            rb.linearVelocity= new Vector2(moveSpeed,rb.linearVelocity.y);
        }
        else
        {   transform.localScale = new Vector3 (1f,1f,1f);
            rb.linearVelocity= new Vector2(-moveSpeed,rb.linearVelocity.y);
        }
    }
}
