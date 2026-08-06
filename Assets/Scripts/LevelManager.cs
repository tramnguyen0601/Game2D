using UnityEngine;
public class LevelManager : MonoBehaviour
{   //bien luu vi tri hoi sinh hien tai
    private Vector3 respawnPoint;
    //bien luu vi tri player
    public Transform Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Player hồi sinh
    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
    }

    //Player đi vào điểm khác
    public void CheckPoint()
    {
        
    }
}
