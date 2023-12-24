using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool PlayerisShooting;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] GameObject Arrow;
    [SerializeField] Transform Bow;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;

    bool isAlive = true;
    bool isShooting = false;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
    
        Die();
    }

    void OnArrowShooting(InputValue value)
    {
        if (!isAlive) { return; }

       
        if (value.isPressed)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }

      
        myAnimator.SetBool("isShooting", true);

        if (isShooting)
        {
            Instantiate(Arrow, Bow.position, transform.rotation);
        }
    }

    void ShootingDone()
{
    PlayerisShooting = false;
    
   
    Animator anim = GetComponent<Animator>();
    
   
    anim.SetBool("isShooting", false);
}




    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return;}
        
        if(value.isPressed)
        {
           
            myRigidbody.velocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);

    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    
    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            isAlive = false;
        }
    }

}
