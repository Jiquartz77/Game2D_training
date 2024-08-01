using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    protected Rigidbody2D rb;
    protected Animator anim;

    [Header("Movement Info")]
    [SerializeField] protected float horizontalSpeed = 1.0f;
    [SerializeField] protected int facingDirection = 1;
    [SerializeField] protected bool facingRight = true;

    [Header("Collision Check")]
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance = 0.3f;
    [SerializeField] protected bool isGrounded = true;
    [Space]
    [SerializeField] protected LayerMask whatIsWall;
    [SerializeField] protected bool isHitWall = false;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance = 1.5f;

    protected virtual void Start(){
        rb=GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        if (wallCheck == null){
            wallCheck = transform;
        }
    }

    protected virtual void Update(){
        CollisionChecks();
        FacingFlipController();
    }

    protected virtual void CollisionChecks() {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

        if (wallCheck != null)  {
            isHitWall = Physics2D.Raycast(wallCheck.position, Vector2.right , wallCheckDistance * facingDirection, whatIsWall);
            Debug.DrawLine(wallCheck.position, new Vector3 (wallCheck.position.x + wallCheckDistance * facingDirection, wallCheck.position.y), Color.green);
        }
    }
    protected virtual void OnDrawGizmos() { 
        if (groundCheck != null) { 
            Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance)); 
        }
        if (wallCheck != null)  {
            Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDirection, wallCheck.position.y )); 
        }
    }

    protected virtual void FacingFlip(){
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    protected virtual void FacingFlipController() {
        if (rb.velocity.x < 0 && facingRight) {
            FacingFlip();
        }
        else if (rb.velocity.x > 0 && !facingRight) {
            FacingFlip();
        }
    }
}