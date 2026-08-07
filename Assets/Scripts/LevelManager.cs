//player: Ai sẽ được hồi sinh?
//respawnPoint: Hồi sinh ở đâu?
//UpdateCheckpoint():Cập nhật điểm hồi sinh mới.
//RespawnPlayer():Đưa Player về điểm hồi sinh.
//Transform: vị trí
// Vector: tọa độ
using JetBrains.Annotations;
using UnityEngine;
public class LevelManager : MonoBehaviour
{   //bien luu vi tri hoi sinh hien tai
    private Vector3 respawnPoint;
    //bien luu vi tri player cần hồi sinh
    public Transform player;
    public static LevelManager instance;
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
        player.position = respawnPoint;
        Debug.Log("Player Respawn");

    }

    //Cập nhật điểm hồi sinh mới
    public void UpdateCheckPoint(Vector3 newCheckpoint)
    {
       respawnPoint = newCheckpoint;
    }
}
