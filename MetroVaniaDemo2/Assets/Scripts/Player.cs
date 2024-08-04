using UnityEditor.Callbacks;
using UnityEngine;

public class Player :MonoBehaviour{
    public PlayerStateMachine stateMachine{get; private set;}
    public PlayerStateIdle stateIdle{get; private set;}
    public PlayerStateMove stateMove{get; private set;}
    public PlayerStateJump stateJump{get; private set;}
    public PlayerStateAir stateAir{get; private set;}
    
    public Animator anim {get; private set;}
    public Rigidbody2D rb {get; private set;}
    
    [Header("Movement")]
    public float horizontalSpeed =8f;
    public float jumpForce = 15.0f;
    public float vX ;
    public float vY ;
    private int facingDirection = 1;
    private bool isFacingRight = true;

    [Header("Collision Detection")]
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckDistance =0.2f;
    public Transform wallCheck;
    public float wallCheckDistance =1.2f;

    private void Awake() {
        stateMachine =new PlayerStateMachine();
        stateIdle = new PlayerStateIdle(stateMachine, this, "isIdle"); 
        stateMove = new PlayerStateMove(stateMachine, this, "isMove"); 
        stateJump = new PlayerStateJump(stateMachine, this, "isJump"); 
        stateAir = new PlayerStateAir(stateMachine, this, "isAir"); 

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start() {
        stateMachine.Initialize(stateIdle);
    }

    private void Update() {
        vX=rb.velocity.x; vY=rb.velocity.y;  // show velocity
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float vx, float vy){
        rb.velocity = new Vector2(vx, vy);
    }

    private void OnDrawGizmos() {
        Debug.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance, Color.green);
        Debug.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * wallCheckDistance *facingDirection, Color.green);
    }
}