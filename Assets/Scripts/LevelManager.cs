//player: Ai sẽ được hồi sinh?
//respawnPoint: Hồi sinh ở đâu?
//UpdateCheckpoint():Cập nhật điểm hồi sinh mới.
//RespawnPlayer():Đưa Player về điểm hồi sinh.
//Transform: vị trí
// Vector: tọa độ
using System.Collections;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class LevelManager : MonoBehaviour
{   //bien luu vi tri hoi sinh hien tai
    private Vector3 respawnPoint;
    //bien luu vi tri player cần hồi sinh
    public Transform player;
    public static LevelManager instance;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float waitTimeDelay;
    private CameraController camera;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Ban đầu hồi sinh vị trí player đứng
        respawnPoint = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Đưa Player về điểm hồi sinh ban đầu
    public void RespawnPlayer()
    
    {
        StartCoroutine(RespawnCorountine());
       //Tao ban sao hieu ung chết: Nó là gì, nằm ở đâu, góc xoay
    //    Instantiate(deathParticle,player.position,Quaternion.identity);

    //    player.position = respawnPoint;
    //    //Tao ban sao hieu ung hồi sinh: Nó là gì, nằm ở đâu, góc xoay
    //    Instantiate(respawnParticle,respawnPoint,Quaternion.identity);
    }
    
     private IEnumerator RespawnCorountine()
     {   
         Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
         rb.linearVelocity = Vector2.zero;
         rb.gravityScale = 0f;
        GameObject depthEffect = Instantiate(deathParticle,player.position,Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        player.gameObject.SetActive(false);
        //camera.isFlowing = false;
        Destroy(depthEffect,2f);
        player.position = respawnPoint;
        //Tao ban sao hieu ung hồi sinh: Nó là gì, nằm ở đâu, góc xoay
        GameObject respawnEffect = Instantiate(respawnParticle,respawnPoint,Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        player.gameObject.SetActive(true);
        //camera.isFlowing = true;
         rb.linearVelocity = Vector2.zero;
         rb.gravityScale = 5f;
        Destroy(respawnEffect,2f);
         
     }

    //Cập nhật điểm hồi sinh mới
    public void UpdateCheckPoint(Vector3 newCheckpoint)
    {
       respawnPoint = newCheckpoint;
    }
}
