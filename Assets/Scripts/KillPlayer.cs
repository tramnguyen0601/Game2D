
using UnityEngine;

public class KillPlayer : MonoBehaviour
{   
    public LevelManager levelManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
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
            levelManager.RespawnPlayer();
        }
    }


}
