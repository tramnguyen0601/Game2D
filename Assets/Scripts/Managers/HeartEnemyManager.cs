using UnityEngine;
public class HeartEnemyManager : MonoBehaviour,IDamage
{
    [SerializeField]private int maxDamageEnemy = 3;
    public int MaxDamageBar =>maxDamageEnemy;
    [SerializeField]private int currentHeart;
    public int CurrentHeart =>currentHeart;
    private void Awake()
    {
        currentHeart = maxDamageEnemy;
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage được gọi, damage = " + damage);
        currentHeart = currentHeart - damage;
        if(currentHeart <= 0)
        {   
            currentHeart = 0;
            Destroy(gameObject);
            return;
        }
    }
}
