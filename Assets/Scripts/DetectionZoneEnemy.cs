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
        //Debug.Log("Có object vào vùng: " + collision.name);
        if(collision.CompareTag("Player"))
        {
            enemyController.playerInRange = true;// player vào vùng
            Debug.Log("VÀO VÙNG → playerInRange = TRUE");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("Có object vào vùng: " + collision.name);
        if(collision.CompareTag("Player"))
        {
            enemyController.playerInRange = false;//player ra ngoài vùng
            Debug.Log("RA VÙNG → playerInRange = FALSE");
        }
    }
}
