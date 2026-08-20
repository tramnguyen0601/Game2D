using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private int numLife = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("vô");
        if (collision.CompareTag("Player"))
        {
            ILife taget = GetComponent<ILife>();
            if (taget != null)
            {
                taget.LoseLife(numLife);
            }
            Destroy(gameObject);
        }
    }
}
