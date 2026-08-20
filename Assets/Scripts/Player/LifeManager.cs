using System;
using UnityEngine;
using UnityEngine.UI;
public class LifeManager : MonoBehaviour
{
   [SerializeField] public int maxLife = 5;  //biến lưu số mạng sống tối đa của Player;
   [SerializeField] private int currentLife; //biến lưu mạng hiện tại của Player;
   public static LifeManager instance;
   [SerializeField] private Text lifeText;   //biến lưu text hiển thị trên màn hình số mạng Player;
   public int CurrentLife
    {
        get
        {
            return currentLife;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentLife = maxLife;
        UpdateLifeText();
    }
    public void LoseLife(int life)
    {
        //currentLife --; //giảm 1 mạng;
        currentLife = maxLife - life;
        UpdateLifeText();
    }
    private void UpdateLifeText()
    {
        if(currentLife < 0)
        {
            currentLife = 0;
        }
        lifeText.text = currentLife.ToString();
    }
}

