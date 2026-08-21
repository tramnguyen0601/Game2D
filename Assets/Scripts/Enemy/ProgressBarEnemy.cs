using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarEnemy : MonoBehaviour
{
    [SerializeField] private Image progressBarHP;
    [SerializeField] private Text valueProgressHP;
    private void Start()
    {
        UpdateProgressBar();
    }
    private void Update()
    {
        UpdateProgressBar();
    }
    private void UpdateProgressBar()
    {   
        HeartEnemyManager heartEnemyManager = GetComponentInParent<HeartEnemyManager>();

        float percentHeart = (float) heartEnemyManager.CurrentHeart / heartEnemyManager.MaxDamageBar;
        progressBarHP.fillAmount = percentHeart;
        string valueText = heartEnemyManager.CurrentHeart + "/" + heartEnemyManager.MaxDamageBar;
        valueProgressHP.text = valueText;
        
    }
}
