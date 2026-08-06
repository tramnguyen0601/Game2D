//Xac dinh class: player, 
//Variable: toc do nhay, toc do di chuyen, player muon dieu khien vat ly: Rigidbody2D
//Function: Nhay, di chuyen
//dùng thư viện có sẵn của unity namespace
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController:MonoBehaviour
{   
    //khai bao bien luu toc do di chuyen cua player: trai phai
    public float moveSpeed;
    //khai bao bien luu toc do nhay cua player
    public float jumpHeight;
    //vat ly
    private Rigidbody2D rb;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
       
    }
    void Update()
    {    
        // if(Keyboard.current.spaceKey.isPressed)
        // {
        //     rb.AddForce(Vector2.up*jumpHeight);
        // }
         Debug.Log("Update đang chạy");
        //if(Input.GetKey(KeyCode.LeftArrow))
        if(Keyboard.current.rightArrowKey.isPressed)
        {
            rb.linearVelocity = new Vector2(moveSpeed,rb.linearVelocity.y);
        }
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            rb.linearVelocity= new Vector2(-moveSpeed,rb.linearVelocity.y);
        }
        if(Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            rb.linearVelocity= new Vector2(rb.linearVelocity.x,jumpHeight);
        }
    }
}