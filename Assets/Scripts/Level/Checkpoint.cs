using UnityEngine;

public class Checkpoint : MonoBehaviour
{   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            LevelManager.instance.UpdateCheckPoint(transform.position);
        }
    }
}
