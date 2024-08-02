using UnityEditor.Callbacks;
using UnityEngine;

public class Player :MonoBehaviour{
    public PlayerStateMachine stateMachine{get; private set;}
    public PlayerStateIdle stateIdle{get; private set;}
    public PlayerStateMove stateMove{get; private set;}
    
    public Animator anim {get; private set;}
    public Rigidbody2D rb {get; private set;}
    
    [Header("Movement")]
    public float horizontalSpeed =8f;
    public float vX ;
    //public float horizontalSpeed {get; private set;}

    private void Awake() {
        stateMachine =new PlayerStateMachine();
        stateIdle = new PlayerStateIdle(stateMachine, this, "isIdle"); 
        stateMove = new PlayerStateMove(stateMachine, this, "isMove"); 

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start() {
        stateMachine.Initialize(stateIdle);
    }

    private void Update() {
        vX=rb.velocity.x;
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float vx, float vy){
        rb.velocity = new Vector2(vx, vy);
    }
}