using UnityEngine;
using UnityEngine.Timeline;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    public bool isFlowing;
    public float xOffset;
    public float yOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFlowing = true;
        //yOffset = 0f;
    }

    // Update is called once per frame
    void Update()
    {   
        if(isFlowing)
        {
           transform.position = new Vector3 (player.transform.position.x + xOffset,player.transform.position.y+yOffset,transform.position.z);
        }
    }
    // Gọi khi Player chạm DeathGround
    public void DeathCamera()
    {
        yOffset = 3.1f;
    }

    // Gọi khi Player hồi sinh xong
    public void NormalCamera()
    {
        yOffset = 0f;
    }
}
