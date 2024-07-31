using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
    [Header("Movement")]
    [SerializeField] private float horizontalSpeed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float xInput ;
    [SerializeField] private float velocity_x;
    [SerializeField] private float dashTimer =0;
    [SerializeField] private float dashSpeed = 20.0f;
    [SerializeField] private float dashCoolDownDuration = 0.8f;
    [SerializeField] private float dashDuration =0.4f;
    //[SerializeField] private float dashCoolDownTimer = 0f;
    [SerializeField] private bool  isDashing = false;

    [Header("Attack")]
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private int comboCounter = 0;
    [SerializeField] private float comboCounterTimer = 0;
    [SerializeField] private float comboCounterDuration = 0.5f;
    private int attackNumber = 3;

    
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
        velocity_x = rb.velocity.x;
    }

    void Update() {

        //dashCoolDownTimer -= Time.deltaTime;

        dashTimer -= Time.deltaTime;
        comboCounterTimer -= Time.deltaTime;
        dashTimer %= 10;
        comboCounterTimer %= 10;

        velocity_x = rb.velocity.x;  // show vel.x

        CheckInput();
        CollisionChecks();
        AnimatorController();
        FacingFlipController();
    }


    void CheckInput(){
        xInput = Input.GetAxis("Horizontal");
        if (comboCounterTimer <0){ comboCounter = 0; }

        Movement();

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }else if (Input.GetKeyDown(KeyCode.LeftShift)){
            Dash();
        }

    }

    private void Attack() {
        if (isGrounded) {
            isAttacking = true;
            comboCounterTimer = comboCounterDuration;
        }
    }

    private void Movement() {
        if (!isAttacking) {
            if (dashTimer > 0) {
                rb.velocity = new Vector2(facingDirection * dashSpeed, 0);
            }
            else {
                rb.velocity = new Vector2(xInput * horizontalSpeed, rb.velocity.y);
                //rb.AddForce(new Vector2(xInput * horizontalSpeed, 0));
            }
        }
    }

    private void Dash(){
        if (dashTimer < - dashCoolDownDuration){
            dashTimer = dashDuration;
        }
        //dashCoolDownTimer = dashCoolDownDuration;
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
        player_AC.SetBool("isAttacking", isAttacking);
        player_AC.SetInteger("comboCounter", comboCounter);
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

    public void AttackEnd(){ 
        isAttacking = false; 
        comboCounter++;
        comboCounter %= attackNumber;
    }

    private void CollisionChecks(){
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    // private void OnDrawGizmos() { Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance)); }

/*     
private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (isGrounded) rb.AddForce(transform.up * jumpForce);
        }
    }
*/
}