using UnityEngine;

public class DeathGround : MonoBehaviour
{
    [SerializeField]private int penalty;  //biến lưu điểm trừ khi va chạm
    [SerializeField]private int damage;   //biến lưu trừ máu khi va chạm
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {   
            LevelManager.instance.RespawnPlayer();
            IDamage taget = collision.GetComponent<IDamage>();
            if (taget!= null)
            {
                taget.TakeDamage(damage);
            }
            ScoreManager.instance.AddPoints(-penalty);
        }
    }
}
