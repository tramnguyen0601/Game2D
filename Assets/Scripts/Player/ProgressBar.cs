using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressBarHP;
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
        HeartManager heartManager = HeartManager.instance;
        //Debug.Log("heartManager.CurrentHeart: "+ HeartManager.instance.CurrentHeart);
        float percentHeart = (float) heartManager.CurrentHeart / heartManager.MaxDamageBar;
        progressBarHP.fillAmount = percentHeart;
        
    }
}
