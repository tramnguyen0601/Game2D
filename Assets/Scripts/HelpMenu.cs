using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject helpPanel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        helpPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenHelpPanel()
    {
        helpPanel.SetActive(true);
        Time.timeScale = 0f;

    }
    public void CloseHelpPanel()
    {
        Time.timeScale = 1f;
        helpPanel.SetActive(false);
    }
}
