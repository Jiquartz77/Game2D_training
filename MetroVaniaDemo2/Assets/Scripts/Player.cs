using System.Threading;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player :MonoBehaviour{
    public PlayerStateMachine stateMachine{get; private set;}
    public PlayerStateIdle stateIdle{get; private set;}
    public PlayerStateMove stateMove{get; private set;}
    public PlayerStateJump stateJump{get; private set;}
    public PlayerStateAir stateAir{get; private set;}
    public PlayerStateDash stateDash{get; private set;}
    
    public Animator anim {get; private set;}
    public Rigidbody2D rb {get; private set;}
    
    [Header("Movement")]
    public readonly float horizontalSpeed =8f;
    public readonly float dashSpeed = 15f;
    public readonly float dashDuration = 0.6f;
    public readonly float dashCooldown = 1.2f;
    protected float dashCooldownTimer = 0f;
    public float jumpForce = 25.0f;
    public float vX ;
    public float vY ;
    private bool isFacingRight; 
    public int facingDirection {get;private set;}
    public float inputDirection {get; private set;}

    [Header("Collision Detection")]
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;
    public Transform groundCheck;
    public Transform wallCheck;
    public float groundCheckDistance =0.2f;
    public float wallCheckDistance =0.5f;

    private void Awake() {
        Application.targetFrameRate =90;

        stateMachine =new PlayerStateMachine();
        stateIdle = new PlayerStateIdle(stateMachine, this, "isIdle"); 
        stateMove = new PlayerStateMove(stateMachine, this, "isMove"); 
        stateJump = new PlayerStateJump(stateMachine, this, "isJump"); 
        stateAir = new PlayerStateAir(stateMachine, this, "isAir"); 
        stateDash = new PlayerStateDash(stateMachine, this, "isDash"); 

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        facingDirection=1;
        isFacingRight = true;
    }

    private void Start() {
        stateMachine.Initialize(stateIdle);
    }

    private void Update() {
        vX=rb.velocity.x; vY=dashCooldownTimer;  // show velocity

        dashCooldownTimer -=Time.deltaTime;
        dashCooldownTimer %= 100;
        stateMachine.currentState.Update();
        CheckInput();
    }

    public void SetVelocity(float vx, float vy){
        rb.velocity = new Vector2(vx, vy);
        FlipController(rb.velocity.x);
    }

    private void CheckInput(){
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            inputDirection = Input.GetAxisRaw("Horizontal") ;

            //if inputDirection==0
            if (inputDirection <float.Epsilon && inputDirection > -float.Epsilon){
                inputDirection =facingDirection;
            }
            if (dashCooldownTimer< 0){
                dashCooldownTimer = dashCooldown;
                stateMachine.ChangeState(stateDash);
            }
        }
    }

    private void OnDrawGizmos() {
        Debug.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance, Color.green);
        Debug.DrawLine(wallCheck.position, wallCheck.position + facingDirection * wallCheckDistance * Vector3.right, Color.green);
    }

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.down, wallCheckDistance, whatIsWall);

    public void Flip() {
        isFacingRight = !isFacingRight;
        facingDirection *= -1;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float x) {
        if (x < 0 && isFacingRight){
            Flip();
        }else if (x > 0 && !isFacingRight){
            Flip();
        }
    }
}