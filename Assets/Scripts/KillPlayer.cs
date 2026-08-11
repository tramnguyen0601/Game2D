
using UnityEngine;

public class KillPlayer : MonoBehaviour
{   public int penalty;
    public int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Phat hien Player đi vao vung Trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            LevelManager.instance.RespawnPlayer();
            HeartManager.instance.TakeDamge(damage);
            ScoreManager.instance.AddPoints(-penalty);
        }
    }


}
