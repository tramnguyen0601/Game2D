using System;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField]private int maxDamge = 5;//biến lưu số lương tối đa máu/1 mạng;
    public int MaxDamageBar => maxDamge;
    private int currentHeart;            //biến lưu máu hiện tại;
    public int CurrentHeart => currentHeart; //property;
    // public int CurrentHeart
    // {
    //     get
    //     {
    //         return currentHeart;
    //     }
    // }
    public GameObject gameOverPanel;     //biến lưu UI GameOver;
    public static HeartManager instance; 
    public Text heartText;              //biến lưu text hiển thị máu;
    void Awake()
    {
        instance = this;
        currentHeart = maxDamge;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateDamage();
        
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("voo");
        currentHeart = currentHeart - damage;
        if(currentHeart < 0 || currentHeart == 0)
        {
            LoseLife();
            // gameOverPanel.SetActive(true);
            //    // Time.timeScale = 0f;  
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
