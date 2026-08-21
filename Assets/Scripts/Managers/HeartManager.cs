using System;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour,IDamage
{
    [SerializeField]private int maxDamge = 5;                //biến lưu số lương tối đa máu/1 mạng;
    public int MaxDamageBar => maxDamge;
    private int currentHeart;                               //biến lưu máu hiện tại;
    public int CurrentHeart => currentHeart;               //property;
    // public int CurrentHeart
    // {
    //     get
    //     {
    //         return currentHeart;
    //     }
    // }
    [SerializeField]private GameObject gameOverPanel;     //biến lưu UI GameOver;
    public static HeartManager instance; 
    [SerializeField]private Text heartText;              //biến lưu text hiển thị máu;
    [SerializeField]private int lastScore = 0;           //biến lưu lại các mốc điểm dùng để + 1HP;
    [SerializeField]private int maxscoreHP = 300;        //biến lưu tổng điểm có thể được +1HP;
    [SerializeField]private int maxHeartHP = 10;         //biến lưu max máu không được cộng nữa;

    void Awake()
    {
        instance = this;
        currentHeart = maxDamge;
    }
    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateDamage();
        
        
    }
    private void Update()
    {
        AddHeart();
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("voo");
        currentHeart = currentHeart - damage;
        if(currentHeart <=0)
        {
            LoseLife();
            // gameOverPanel.SetActive(true);
            //    // Time.timeScale = 0f;  
        }
        UpdateDamage();
    }
    private void AddHeart()//Hàm add +1HP khi đủ Score = 300
    {
        int score = ScoreManager.instance.Score;
        if(score >= lastScore + maxscoreHP)
        {
            currentHeart = currentHeart + 1;
            lastScore = lastScore + maxscoreHP;
            if(currentHeart >= maxHeartHP)
            {
                currentHeart = maxHeartHP;
            }
        }
        UpdateDamage();
    }
    private void LoseLife()
    {
        LifeManager.instance.LoseLife(1);//Hết máu trừ 1 mạng;
        if(LifeManager.instance.CurrentLife > 0)// kiểm tra nếu còn mạng hồi máu lại ,ngược lại hiện gameover
        {
            currentHeart = maxDamge;
        }
        else
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void UpdateDamage()
    {   
        if(currentHeart < 0)
        {
            currentHeart = 0;
        }
        heartText.text = currentHeart.ToString();
    }
}
