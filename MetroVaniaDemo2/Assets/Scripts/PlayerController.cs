using UnityEngine;
using System.Collections;


public class ExampleClass : MonoBehaviour {
    [Header("Movement")]
    [SerializeField] private float horizontalSpeed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float xInput ;
    [SerializeField] private float velocity_x;
    [SerializeField] private float dashDuration =0.7f;
    [SerializeField] private float dashTimer =0;
    [SerializeField] private float dashSpeed = 30.0f;
    [SerializeField] private float dashCoolDownDuration = 2.0f;
    [SerializeField] private float dashCoolDownTimer = 0f;
    [SerializeField] private bool canDash = true;

    
    private Rigidbody2D rb;
    private Animator player_AC;

    private int facingDirection = 1;
    private bool facingRight = true;

    [Header("Collision")]
    private bool isGrounded;
    private float groundCheckDistance = 1.9f;
    [SerializeField] private LayerMask whatIsGround;

    void Start() {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        player_AC = GetComponentInChildren<Animator>();
    }

    void Update() {
        xInput = Input.GetAxis("Horizontal");

        dashTimer -= Time.deltaTime;
        dashCoolDownTimer -= Time.deltaTime;
        if (dashTimer < -10){ dashTimer %= 10; }
        if (dashCoolDownTimer < -10){ dashTimer %= 10; }
        velocity_x = rb.velocity.x;

        CheckInput();
        CollisionChecks();
        AnimatorController();
        FacingFlipController();
    }


    void CheckInput(){
        Movement();
        if (Input.GetButtonDown("Horizontal")) { }
        else if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }else if (Input.GetKeyDown(KeyCode.LeftShift)){
            Dash();
        }

    }

    private void Movement() {
        if (dashTimer > 0 && canDash){
            rb.velocity = new Vector2 (facingDirection * dashSpeed, 0);
        }else {
            rb.velocity = new Vector2 (xInput  * horizontalSpeed, rb.velocity.y);
            //rb.AddForce(new Vector2(xInput * horizontalSpeed, 0));
        }
    }

    private void Dash(){
        dashTimer = dashDuration;
        dashCoolDownTimer = dashCoolDownDuration;
    }

    private void Jump() {
        if (isGrounded){
            rb.velocity = new Vector2 ( rb.velocity.x, jumpForce);
            //rb.AddForce(new Vector2(0, jumpForce));
        }
        //rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
    }

    private void AnimatorController(){
        bool isMoving = (rb.velocity.x != 0);
        player_AC.SetBool("isMoving", isMoving);
        player_AC.SetBool("isGrounded", isGrounded);
        player_AC.SetFloat("yVelocity", rb.velocity.y);
        player_AC.SetBool("isDashing", dashTimer > 0);
    }

    private void FacingFlip(){
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FacingFlipController(){
        if (rb.velocity.x < 0 && facingRight) {
            FacingFlip();
        }
        else if (rb.velocity.x > 0 && !facingRight) {
            FacingFlip();
        }
    }

    // private void OnDrawGizmos() { Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance)); }

    private void CollisionChecks(){
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

/*     private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (isGrounded) rb.AddForce(transform.up * jumpForce);
        }
    } */
}