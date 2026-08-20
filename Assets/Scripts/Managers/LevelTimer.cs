using UnityEngine;
using UnityEngine.UI;

public class LevelTimer:MonoBehaviour
{
    public float levelTime;// tạo biến lưu time gian ban đầu
    private bool isGameover; //kiểm tra nếu gameover là dừng luôn
    public GameObject gameOver;
    public Text timeText;
    // Update is called once per frame
    void Start()
    {
        gameOver.SetActive(false);
    }
    void Update()
    {
        if (isGameover)
        {
            return;
        }
        
        if(levelTime < 0 || levelTime == 0)
        {   
            levelTime = 0;
            isGameover = true;
            gameOver.SetActive(true);
            Time.timeScale = 0f;

        }
        else
        {
            levelTime = levelTime - Time.deltaTime;
        }
        int minutes = Mathf.FloorToInt(levelTime / 60); // Mathf.FloorToInt: đổi thập phân -> số nguyên
        int seconds = Mathf.FloorToInt(levelTime % 60); // Mathf.FloorToInt: đổi thập phân -> số nguyên
        timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
