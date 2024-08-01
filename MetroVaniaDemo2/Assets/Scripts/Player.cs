using UnityEngine;
using System.Collections;


public class Player : Entity {
    [Header("Player Movement")]
    [SerializeField] private float jumpForce = 20.0f;
    [SerializeField] private float xInput ;
    [SerializeField] private float velocity_x;
    [SerializeField] private float dashTimer =0;
    [SerializeField] private float dashSpeed = 20.0f;
    [SerializeField] private float dashCoolDownDuration = 0.8f;
    [SerializeField] private float dashDuration =0.4f;
    //[SerializeField] private float dashCoolDownTimer = 0f;
    [SerializeField] private bool  isDashing = false;

    [Header("Player Attack")]
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private int comboCounter = 0;
    [SerializeField] private float comboCounterTimer = 0;
    [SerializeField] private float comboCounterDuration = 0.7f;
    private readonly int attackNumber = 3;

    protected override void Start() {
        Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        velocity_x = rb.velocity.x;
    }

    protected override void Update() {
        //dashCoolDownTimer -= Time.deltaTime;

        dashTimer -= Time.deltaTime;
        comboCounterTimer -= Time.deltaTime;
        dashTimer %= 10;
        comboCounterTimer %= 10;

        velocity_x = rb.velocity.x;  // show vel.x

        //Player
        CheckInput();
        AnimatorController();

        //Entity
        CollisionChecks();
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
                isDashing =true;
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
            isAttacking =false;
            //rb.AddForce(new Vector2(0, jumpForce));
        }
        //rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
    }

    private void AnimatorController(){
        bool isMoving = (rb.velocity.x != 0);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isDashing", dashTimer > 0);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
    }

    public void AttackEnd(){ 
        isAttacking = false; 
        comboCounter++;
        comboCounter %= attackNumber;
    }




    /*     
    private void FixedUpdate() {
            if (Input.GetKeyDown(KeyCode.Space)){
                if (isGrounded) rb.AddForce(transform.up * jumpForce);
            }
        }
    */
}