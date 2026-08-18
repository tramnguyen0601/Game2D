using UnityEngine;

public class DetectionZoneEnemy : MonoBehaviour
{
    public EnemyController enemyController;
    void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
        enemyController.playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    
    {
        if(collision.CompareTag("Player"))
        {
            enemyController.playerInRange = true;// player vào vùng
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            enemyController.playerInRange = false;//player ra ngoài vùng
        }
    }
}
