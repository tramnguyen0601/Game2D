using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAgainGame()
    {   
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
