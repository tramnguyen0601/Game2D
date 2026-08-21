using UnityEngine;
using UnityEngine.PlayerLoop;

public class Pickup : MonoBehaviour
{   
    [SerializeField]private int score; //biến lưu điểm được cộng khi va chạm coin;
    [SerializeField]private float moveSpeed;            //biến lưu tốc độ di chuyển của coin;
    [SerializeField]private float moveHeight;          //biến lưu tốc độ nhún của coin;
    [SerializeField]private Vector3 newCoinPosition;
    private Animator animator;
    private int randomState;
    private float randomOffset;
    [SerializeField]private AudioClip coinSound;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {  
        
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
    private void Update()
    {
         Bounce();
    }
    private void Bounce()
    {
        float newY = newCoinPosition.y +
            Mathf.Sin(Time.time * moveSpeed + randomOffset)
            * moveHeight;

        transform.position = new Vector3(newCoinPosition.x,newY,newCoinPosition.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            ScoreManager.instance.AddPoints(score);
            AudioSource.PlayClipAtPoint(coinSound,transform.position); //phát âm thanh coin khi player va chạm
            Destroy(gameObject);//Hủy coin trên scene;
        }
    }
        
}
