using UnityEngine;
using UnityEngine.Playables;

public class PlayerState {
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animBoolName;

    //Other Properties
    protected Rigidbody2D rb;
    protected float xInput;
    protected float yInput;
    protected static float stateTimer;
    protected bool triggerCalled;

    public PlayerState(PlayerStateMachine stateMachine, Player player, string animBoolName) {
        this.stateMachine = stateMachine;
        this.player = player;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter(){
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        stateTimer = 0;
        triggerCalled = false;

        Debug.Log("Enter " + animBoolName);
    }

    public virtual void Update(){
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        player.anim.SetFloat("yVelocity", rb.velocity.y);
        player.anim.SetFloat("xVelocity", rb.velocity.x);
        player.anim.SetFloat("xInput", xInput);
        player.anim.SetFloat("yInput", yInput);

        stateTimer -= Time.deltaTime; stateTimer %=100;

        Debug.Log("In " + animBoolName);
    }

    public virtual void Exit(){
        player.anim.SetBool(animBoolName, false);
        Debug.Log("Exit " + animBoolName);
    }

    public virtual void AnimationFinishTrigger(){
        triggerCalled = true;
    }
}