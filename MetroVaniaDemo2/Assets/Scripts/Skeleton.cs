using UnityEngine;
using System.Collections;
using UnityEngine.Scripting.APIUpdating;

public class Skeleton : Entity {

    [Header("Player Detected")]
    [SerializeField] protected float playerCheckDistance;
    [SerializeField] protected LayerMask whatIsPlayer;
    [SerializeField] protected RaycastHit2D isPlayerDetected;
    [SerializeField] protected float acceleratedSpeed;

    protected override void Start(){
        acceleratedSpeed = 5f;
        horizontalSpeed =2f;
        isGrounded =true;
        playerCheckDistance = 10f;
        base.Start();
        
        //flip
        FacingFlip();
        facingRight = false;
        facingDirection = -1;
    }

    protected override void Update(){

        //Entity
        Movement();
        CollisionChecks();
        FacingFlipController();
    }

    private void Movement(){
        if (!isGrounded || isHitWall){
            FacingFlip();
        }

        if (isPlayerDetected == null){
            rb.velocity = new Vector2(facingDirection * horizontalSpeed, rb.velocity.y );
        }
        else if (isPlayerDetected.distance > playerCheckDistance){
            rb.velocity = new Vector2(facingDirection * acceleratedSpeed, rb.velocity.y );
            Debug.Log("I see you!");
        }
        else {
            //isAttacking = true;
            Debug.Log("Attack!");
        }
    }

    protected override void CollisionChecks(){
        base.CollisionChecks();
        isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right , playerCheckDistance * facingDirection, whatIsPlayer);
        //Debug.DrawLine(transform.position, new Vector3 (transform.position.x + playerCheckDistance * facingDirection, transform.position.y), Color.green);
    }

    protected override void OnDrawGizmos() {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position - transform.up, transform.position + facingDirection * playerCheckDistance * Vector3.right - transform.up);
    }
}