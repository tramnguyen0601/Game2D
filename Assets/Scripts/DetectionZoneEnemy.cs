using UnityEditor;
using UnityEngine;

public class DetectionZoneEnemy : MonoBehaviour
{
    public EnemyController enemyController;
    public LayerMask playerLayer;
    private Vector2 direction;
    public float radius = 10f;
    void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
        enemyController.playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyController.moveRight)
        {
            direction = Vector2.right;
        }
        else 
        {
            direction = Vector2.left;
        }
        //Physics2D.Raycast (điểm bắt đầu,hướng ,khoảng cách,layer cần kiểm tra)
        RaycastHit2D raycartHit = Physics2D.Raycast(transform.position,direction,radius,playerLayer);
        if(raycartHit.collider != null)
        {
            
            enemyController.playerInRange = true;// player vào vùng

        }
        else
        {
            enemyController.playerInRange = false;//player ra ngoài vùng
        }
    }
    //2 hàm này dùng cho trường hợp circle Collider2D
    // void OnTriggerEnter2D(Collider2D collision)
    
    // {
    //     if(collision.CompareTag("Player"))
    //     {
    //         enemyController.playerInRange = true;// player vào vùng
    //     }
    // }
    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     if(collision.CompareTag("Player"))
    //     {
    //         enemyController.playerInRange = false;//player ra ngoài vùng
    //     }
    // }
}
