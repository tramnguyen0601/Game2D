using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score;
    public Text scoreText;
    private int heart;
    public int heartText;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void AddPoints(int points)
    {
        score = score + points;
        UpdateScoreUI();
        
    }
    void UpdateScoreUI()
    {
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = score.ToString();
        Debug.Log("score------------"+ score);
    }
    
}
