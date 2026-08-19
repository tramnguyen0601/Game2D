using System;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public int maxDamge;//mang song
    private int currentHeart;
    public GameObject gameOverPanel;
    public static HeartManager instance;
    public Text heartText;
    private int currentLife;
    public int maxLive = 300;//heart
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

    public void TakeDamage(int damage)
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
        if(currentHeart < 0)
        {
            currentHeart = 0;
        }
        heartText.text = currentHeart.ToString();
    }

    // //note de doi life = heart
    // public void AddLivePlayer()
    // {
    //     currentLife = 0;
    //     currentLife = currentLife + dameLife;
    //     if(currentLife == maxDamge)
    //     {
            
    //     }
        
    // }
}
