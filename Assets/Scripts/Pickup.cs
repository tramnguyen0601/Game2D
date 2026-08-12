using UnityEngine;

public class Pickup : MonoBehaviour
{   
    public int score;
    public float moveSpeed;
    public float moveHeight;
    public Vector3 newCoinPosition;
    private Animator animator;
    private int randomState;
    private float randomOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        animator = GetComponent<Animator>();
        //randomState = Random.Range(0,2);
        randomOffset = Random.Range(0f, 6.28f);
        // if(randomState == 0)
        // {
        //     animator.enabled = true;
        // }
        // else
        // {
        //     animator.enabled = false;
        // }
        newCoinPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         Bounce();
        // if(randomState == 1)
        // {
        //     Bounce();
        // }
    }
    // void Bounce()
    
    // {
    //     float newY = newCoinPosition.y
    //                + Mathf.Sin(Time.time * moveSpeed) * moveHeight;

    //     transform.position = new Vector3(
    //         newCoinPosition.x,
    //         newY,
    //         newCoinPosition.z
    //     );
    // }
    void Bounce()
    {
        float newY = newCoinPosition.y +
            Mathf.Sin(Time.time * moveSpeed + randomOffset)
            * moveHeight;

        transform.position = new Vector3(
            newCoinPosition.x,
            newY,
            newCoinPosition.z
        );
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            ScoreManager.instance.AddPoints(score);
            Destroy(gameObject);// huy coin
        }
    }
        
}
