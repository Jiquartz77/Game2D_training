using UnityEngine;

public class PlayerStateMove : PlayerState
{

    public PlayerStateMove(PlayerStateMachine stateMachine, Player player, string animBoolName) 
    : base(stateMachine, player, animBoolName) {
    }
    
    public override void Enter() {
        base.Enter();
    }

    public override void Update() {
        player.SetVelocity(xInput * player.horizontalSpeed, rb.velocity.y); 
        if (xInput < float.Epsilon && xInput> -float.Epsilon){
            stateMachine.ChangeState(player.stateIdle);
        }
        base.Update();
    }

    public override void Exit() {

        base.Exit();
    }
}

