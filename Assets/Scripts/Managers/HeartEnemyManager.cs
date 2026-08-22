using UnityEngine;
public class HeartEnemyManager : MonoBehaviour,IDamage
{
    [SerializeField]private int maxDamageEnemy = 3;
    public int MaxDamageBar =>maxDamageEnemy;
    [SerializeField]private int currentHeart;
    public int CurrentHeart =>currentHeart;
    //public static HeartEnemyManager instance;
    private void Awake()
    {
       // instance = this;
        currentHeart = maxDamageEnemy;
    }
    public void TakeDamage(int damage)
    {
        //Debug.Log("TakeDamage được gọi, damage = " + damage);
        currentHeart = currentHeart - damage;
        if(currentHeart <= 0)
        {   
            currentHeart = 0;
            Destroy(gameObject);
            return;
        }
    }
}
