using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score;
    public int Score =>score;
    [SerializeField]private Text scoreText;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UpdateScoreUI();
    }
    public void AddPoints(int points)
    {
        score = score + points;
        //Debug.Log("point------------"+ points);
        UpdateScoreUI();
        
    }
    private void AddHeart()
    {
        
    }
    private void UpdateScoreUI()
    {
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = score.ToString();
        //Debug.Log("score------------"+ score);
    }
    
}
