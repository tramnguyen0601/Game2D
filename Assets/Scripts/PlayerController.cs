//Xac dinh class: player, 
//Variable: toc do nhay, toc do di chuyen, player muon dieu khien vat ly: Rigidbody2D
//Function: Nhay, di chuyen
//dùng thư viện có sẵn của unity namespace
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerController:MonoBehaviour
{   
    //khai bao bien luu toc do di chuyen cua player: trai phai
    public float moveSpeed;
    //khai bao bien luu toc do nhay cua player
    public float jumpHeight;
    //vat ly
    private Rigidbody2D rb;
    //check 
    private bool jumpRequested;
    //check ground
    public bool isGrounded;
    //check nhay 2 lan
    private int jumpCount = 0;
    public int maxJump;
    //Doi tuong có vi tri trong khong gian (kiem tra dat o vi tri nao)
    public Transform groundCheck; //có position, rotation, size
    // ban kinh kiem tra mat dat
    public float checkgroundRadius; // check ban kính chan player & ground
    //xac dinh loai vat the nao la mat dat
    public LayerMask groundLayer;
    private Animator animator;
    //check trang thái quay: mặc định bên phải
    public Transform bulletPoint;
    public GameObject bullet;
    public GameObject gun;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gun.SetActive(false);
    }
    
    void FixedUpdate()
    {    
        Move();
        
        if(jumpRequested)
        {   
            Jump();
            jumpRequested = false; //xóa để không tự động nhảy khi chưa nhấp
        }
    }
    void Update() 
    {    //kiem tra có dang dung dat khong
         isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkgroundRadius,groundLayer);
         //Debug.Log("isGrounded"+ isGrounded);
         animator.SetBool("Grounded",isGrounded);
         //Check neu cham dat thi reset so lan nhay
        if (isGrounded)
        {
            jumpCount = 0;
        }
        if(Keyboard.current.upArrowKey.wasPressedThisFrame) //xử lý ở đây để không bị miss
        {   
            if(jumpCount < maxJump)
            {
               jumpRequested = true;
            }
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {   
            Debug.Log("SPACE ĐƯỢC NHẤN");
            StartCoroutine(ShowGun());
            Instantiate(bullet,bulletPoint.position,bulletPoint.rotation);
        }
    }
    
    private IEnumerator ShowGun()
{
        gun.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        gun.SetActive(false);
}
    void Jump()
    {
        rb.linearVelocity= new Vector2(rb.linearVelocity.x,jumpHeight);
        jumpCount ++;
    }
    void Move()
    {
       float moveInput = 0;
        if(Keyboard.current.rightArrowKey.isPressed)
        {
            //Debug.Log("Right Pressed");
            moveInput = 1;
        }
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            //Debug.Log("Left Pressed");
            moveInput = -1;
        }

        rb.linearVelocity= new Vector2(moveInput * moveSpeed,rb.linearVelocity.y);
        animator.SetFloat("Speed",MathF.Abs(moveInput));
        //van toc > 0
        if (rb.linearVelocityX > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (rb.linearVelocityX < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        
    }
} 