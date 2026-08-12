using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class EndMap : MonoBehaviour
{   
    public GameObject updateLevelText;
    public GameObject gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateLevelText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            StartCoroutine(ShowUpdateLevel(collision));
        }
    }
    private IEnumerator ShowUpdateLevel(Collider2D collider2D)
    {
        Rigidbody2D rb = collider2D.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
        updateLevelText.SetActive(true);
        yield return new WaitForSeconds (2f);
        updateLevelText.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale= 0f;

    }
}
