//player: Ai sẽ được hồi sinh?
//respawnPoint: Hồi sinh ở đâu?
//UpdateCheckpoint():Cập nhật điểm hồi sinh mới.
//RespawnPlayer():Đưa Player về điểm hồi sinh.
//Transform: vị trí
// Vector: tọa độ
using System.Collections;
using UnityEngine;
public class LevelManager : MonoBehaviour
{   
    private Vector3 respawnPoint;           //biến lưu vị trí hồi sinh hiện tại của Player;
    [SerializeField]private Transform player;                //biến lưu: vị trí, góc xoay, kích thước của Player;
    public static LevelManager instance;    //cho phép các class khác truy cập vào đây;
    [SerializeField]private GameObject deathParticle;       //biến lưu particle chết khi Khi Player va chạm đối tượng khác;
    [SerializeField]private GameObject respawnParticle;     //biến lưu particle hồi sinh tại checkpoint đã đi qua;
    [SerializeField]private float waitTimeDelay;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        respawnPoint = player.position; //lưu vị trí ban đầu đứng của Player;
    }
    //Đưa Player về điểm hồi sinh ban đầu luc vao start or đã đi qua vị trí checkpoint;
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCorountine());
    }
    
     private IEnumerator RespawnCorountine()
     {   
         Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
         rb.linearVelocity = Vector2.zero;
         rb.gravityScale = 0f;
         //Tao bản sao hiệu ứng chết: Nó là gì, nằm ở đâu, góc xoay
        GameObject depthEffect = Instantiate(deathParticle,player.position,Quaternion.identity);
        yield return new WaitForSeconds(0.5f); //phát thời gian chờ 0.5f;
        player.gameObject.SetActive(false);    //player chết bị ẩn đi;
        Destroy(depthEffect,2f);               //hủy effect trên scene;
        player.position = respawnPoint;        //lưu vị trí mới đã đi qua;
        //Tao bản sao hiệu ứng hồi sinh: Nó là gì, nằm ở đâu, góc xoay
        GameObject respawnEffect = Instantiate(respawnParticle,respawnPoint,Quaternion.identity);
        yield return new WaitForSeconds(0.5f); //phát thời gian chờ 0.5f;
        player.gameObject.SetActive(true);     //player chết hồi sinh->hiện;
         rb.linearVelocity = Vector2.zero;     //vận tốc = 0;
         rb.gravityScale = 5f;                 //trọng lực = 5;
        Destroy(respawnEffect,2f);             //hủy effect trên scene;
         
     }
    //Hàm Cập nhật điểm hồi sinh mới
    public void UpdateCheckPoint(Vector3 newCheckpoint)
    {
       respawnPoint = newCheckpoint;
    }
}
