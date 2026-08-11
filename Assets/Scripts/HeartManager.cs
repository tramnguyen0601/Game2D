using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public int maxDamge;
    private int currentHeart;
    public GameObject gameOverPanel;
    public static HeartManager instance;
    public Text heartText;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHeart = maxDamge;
        gameOverPanel.SetActive(false);
        UpdateDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamge(int damage)
    {
        Debug.Log("voo");
        currentHeart = currentHeart - damage;
        if(currentHeart < 0 || currentHeart == 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            
        }
        UpdateDamage();
        
    }
    void UpdateDamage()
    {
        heartText.text = currentHeart.ToString();
    }
}
