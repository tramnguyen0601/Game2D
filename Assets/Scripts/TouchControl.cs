using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    public void TouchJump()
    {
        playerController.RequestJump();
    }
    public void TouchLeft()
    {
        playerController.MoveLeft();
    }
    public void TouchRight()
    {
        playerController.MoveRight();
    }
}
