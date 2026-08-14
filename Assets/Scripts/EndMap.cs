using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class EndMap : MonoBehaviour
{   
    public bool playInZone;
    public GameObject updateLevelText;
    public string nextLoadLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateLevelText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame && playInZone)
        {
            SceneManager.LoadScene(nextLoadLevel);
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            playInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            playInZone = false;
        }
    }
}
