using UnityEngine;
public class DetectionZoneEnemy : MonoBehaviour
{
    //-----CÁC BIẾN LƯU VỊ TRÍ,PHÁT HIỆN VÙNG ĐƯỢC BẮN CỦA ENEMY-----//
    private EnemyController enemyController;       //biến lưu REFERENCE(tham chiếu) tới 1 object của EnemyController
    [SerializeField]public LayerMask playerLayer;  //biến lưu Layer Player
    private Vector2 direction;                    // biến lưu hướng
    [SerializeField]private float radius = 10f;   //biến lưu bán kính vùng
    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
        //Encapsulation
    }
    private void Start()
    {
        enemyController.SetPlayerInRange(false);
    }

    private void Update()
    {
        CheckDirection(); //hàm kiểm tra phương hướng của Enemy
        DetectPlayer();   //hàm phát hiện Player nằm trong vùng bị bắn
    }
    private void CheckDirection()
    {
        if (enemyController.MoveRight) //Property MoveRight
        {
            direction = Vector2.right;
        }
        else 
        {
            direction = Vector2.left;
        }
    }
    private void DetectPlayer()
    {
        //Physics2D.Raycast (điểm bắt đầu,hướng ,khoảng cách,layer cần kiểm tra)
        RaycastHit2D raycartHit = Physics2D.Raycast(transform.position,direction,radius,playerLayer);
        if(raycartHit.collider != null)
        {
            enemyController.SetPlayerInRange(true);// Player vào vùng
        }
        else
        {
            enemyController.SetPlayerInRange(false);//Player ra ngoài vùng
        }
    }

    //-----2 HÀM NÀY SỬ DỤNG CHO TRƯỜNG HỢP MUỐN BÁN KÍNH ĐƯỢC BẮN CỦA ENEMY RỘNG HƠN - NHIỀU PHƯƠNG HƯỚNG-----
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
