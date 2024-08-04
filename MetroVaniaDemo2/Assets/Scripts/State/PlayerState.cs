using UnityEngine;
using UnityEngine.Playables;

public class PlayerState {
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animBoolName;

    protected Rigidbody2D rb;
    protected float xInput;

    public PlayerState(PlayerStateMachine stateMachine, Player player, string animBoolName) {
        this.stateMachine = stateMachine;
        this.player = player;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter(){
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        Debug.Log("Enter " + animBoolName);
    }

    public virtual void Update(){
        xInput = Input.GetAxis("Horizontal");
        player.anim.SetFloat("yVelocity", rb.velocity.y);

        Debug.Log("In " + animBoolName);
    }

    public virtual void Exit(){
        player.anim.SetBool(animBoolName, false);
        Debug.Log("Exit " + animBoolName);
    }
}