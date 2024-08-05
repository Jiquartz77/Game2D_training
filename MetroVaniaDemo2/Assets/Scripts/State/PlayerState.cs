using UnityEngine;
using UnityEngine.Playables;

public class PlayerState {
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animBoolName;

    //Other Properties
    protected Rigidbody2D rb;
    protected float xInput;
    protected static float stateTimer;

    public PlayerState(PlayerStateMachine stateMachine, Player player, string animBoolName) {
        this.stateMachine = stateMachine;
        this.player = player;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter(){
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        stateTimer = 0;
        Debug.Log("Enter " + animBoolName);
    }

    public virtual void Update(){
        xInput = Input.GetAxis("Horizontal");

        stateTimer -= Time.deltaTime;
        stateTimer %=100;

        Debug.Log("In " + animBoolName);
    }

    public virtual void Exit(){
        player.anim.SetBool(animBoolName, false);
        Debug.Log("Exit " + animBoolName);
    }
}