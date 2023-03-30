using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float move;
    
    [SerializeField]private float moveSpeed = 6f;

    [SerializeField]private bool jumping;
    [SerializeField]private float jumpSpeed = 6f;

    [SerializeField]private float ghostJump;

    [SerializeField]private bool isGrounded;
    public Transform feetPosition;
    public Vector2 sizeCapsule;
    public float angleCapsule;
    public LayerMask whatIsGround;

    [SerializeField]private bool atackingBool;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animationPlayer;

    public bool quadripleAtck, tripleAtck, doubleAtck, lockAtck = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animationPlayer = GetComponent<Animator>();   
    }

    
    void Update()
    {
        //Reconhecer o chao
        isGrounded = Physics2D.OverlapCapsule(feetPosition.position, sizeCapsule, CapsuleDirection2D.Horizontal, angleCapsule, whatIsGround);

        //Input da movimentacao
        move = Input.GetAxisRaw("Horizontal");

        if(move != 0)
        {
            moveSpeed += 19f *Time.deltaTime;

            if(moveSpeed >= 5.5f)
            {
                moveSpeed = 5.5f;
            }
        }
        else{
            moveSpeed = 0;
        }

        //Input do pulo
        if(Input.GetButtonDown("Jump") && ghostJump > 0 && atackingBool == false)
        {
            jumping = true;
        }

        //Input do ataque
        if(Input.GetButtonDown("Fire1") && lockAtck == false)
        {
            atackingBool = true;
            if(isGrounded && !doubleAtck && !tripleAtck && !quadripleAtck)
            {
                animationPlayer.SetBool("SingleAtckGround", true);
                animationPlayer.SetBool("SingleAtckJump", false); 

                animationPlayer.SetBool("DoubleAtck", false);
            }
            else if(!isGrounded)
            {
                animationPlayer.SetBool("SingleAtckJump", true);
                animationPlayer.SetBool("SingleAtckGround", false);

                animationPlayer.SetBool("DoubleAtck", false);
            }
            if(doubleAtck == true){
                animationPlayer.SetBool("SingleAtckGround", false);
                animationPlayer.SetBool("DoubleAtck", true);

                animationPlayer.SetBool("TripleAtck", false);
            }
            if(tripleAtck == true){
                animationPlayer.SetBool("DoubleAtck", false);
                animationPlayer.SetBool("TripleAtck", true);

                animationPlayer.SetBool("QuadAtck", false);
            }
            if(quadripleAtck == true){
                animationPlayer.SetBool("TripleAtck", false);
                animationPlayer.SetBool("QuadAtck", true);
                }
            
        }

        if(atackingBool == true  && isGrounded)
        {
            move = 0;
        }

        //Inverte a posicao
        if(move < 0)
        {
            sprite.flipX = true;
        }else if(move > 0){
            sprite.flipX = false;
        }


        //Animacao 
        if(move != 0)
        {
            animationPlayer.SetBool("Walking",true);
        }else
        {
            animationPlayer.SetBool("Walking",false);

        }

        if(isGrounded)
        {
            ghostJump = 0.003f;
            animationPlayer.SetBool("Falling", false);
            animationPlayer.SetBool("Jumping", false);

        }else if(!isGrounded && rb.velocity.y < 0)
        {
            animationPlayer.SetBool("Falling", true);
        }else if(!isGrounded)
        {
            ghostJump -= Time.deltaTime;
        }

        if(ghostJump <= 0)
        {
            ghostJump = 0;
        }

        if(jumping){
            animationPlayer.SetBool("Jumping", true);
        }
        

       
       

    }

    void FixedUpdate() 
    {
        //Movimentacao
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        //Pulo
        if(jumping)
        {
            rb.velocity = Vector2.up * jumpSpeed;

            jumping = false;
        }

    }

    void EndAnimationAtck()
    {
        animationPlayer.SetBool("SingleAtckGround", false);
        animationPlayer.SetBool("SingleAtckJump", false);

        atackingBool = false;
    }

    void EndAnimationDoubleAtck(){
       animationPlayer.SetBool("DoubleAtck", false);

       doubleAtck = false;
       atackingBool = false; 
    }
    void EndAnimationTrpleAtck(){
        animationPlayer.SetBool("TripleAtck", false);

        tripleAtck = false;
        atackingBool = false;
    }
    void EndAnimationQuadAtck(){
        animationPlayer.SetBool("QuadAtck", false);

        quadripleAtck = false;
        atackingBool = false;
    }

    void EndJumping(){
        animationPlayer.SetBool("Jumping", false);
    }
    
}
