using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour {
    public Animator anim {get; private set;}
    public Rigidbody2D rb {get; private set;}
    public EntityFX fx {get; private set;}

    [Header("Attack")]
    public Transform attackCheck;
    public float attackCheckRadius = 0.8f;

    [Header("Collision Detection")]
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;
    public Transform groundCheck;
    public Transform wallCheck;
    public float groundCheckDistance =0.2f;
    public float wallCheckDistance =0.5f;

    [Header("Movement")]
    protected bool isFacingRight; 
    public int facingDirection {get;private set;}

    protected virtual void Awake(){
    }

    protected virtual void Start(){
        //fx = GetComponentInChildren<EntityFX>();
        fx = GetComponent<EntityFX>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        facingDirection =1;
        isFacingRight = true;
    }

    protected virtual void Update(){
    }

    public virtual void Damage(){
        //Monobehavior.gameObject
        fx.StartCoroutine("FlashFX");
        Debug.Log(gameObject.name + " was damaged.");
    }

    #region Velocity
    public void SetVelocityZero() => rb.velocity = Vector2.zero;

    public void SetVelocity(float vx, float vy){
        rb.velocity = new Vector2(vx, vy);
        FlipController(rb.velocity.x);
    }
    #endregion

    #region Collision Detection
    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right* facingDirection, wallCheckDistance, whatIsWall);

    protected virtual void OnDrawGizmos() {
        Debug.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance, Color.green);
        Debug.DrawLine(wallCheck.position, wallCheck.position + facingDirection * wallCheckDistance * Vector3.right, Color.green);
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion

    #region Flip
    public void Flip() {
        isFacingRight = !isFacingRight;
        facingDirection *= -1;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float x) {
        //x==0, skip
        if (x <=float.Epsilon && x>= -float.Epsilon){
            return;
        }

        if (x < 0 && isFacingRight){
            Flip();
        }else if (x > 0 && !isFacingRight){
            Flip();
        }
    }
    #endregion
}
