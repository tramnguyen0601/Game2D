using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{    
    public Text levelText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int sceneText = SceneManager.GetActiveScene().buildIndex;
        levelText.text = sceneText.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
