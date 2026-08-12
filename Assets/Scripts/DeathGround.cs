using UnityEngine;

public class DeathGround : MonoBehaviour
{
    public int penalty;
    public int damage;
    public CameraController cameraController;
    //Phat hien Player đi vao vung Trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {   
            //cameraController.DeathCamera();
            LevelManager.instance.RespawnPlayer();
            HeartManager.instance.TakeDamge(damage);
            ScoreManager.instance.AddPoints(-penalty);
        }
    }
}
