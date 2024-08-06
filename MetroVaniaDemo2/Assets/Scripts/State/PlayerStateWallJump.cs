using System.Data.Common;
using UnityEngine;

public class PlayerStateWallJump : PlayerState {
    public PlayerStateWallJump(PlayerStateMachine stateMachine, Player player, string animBoolName) : 
    base(stateMachine, player, animBoolName) { }

    public override void Enter() {
        base.Enter();
        stateTimer = player.wallJumpDuration;
        //player.Flip();
        player.SetVelocity(-player.facingDirection * 5, player.jumpForce);
    }

    public override void Update() {
        base.Update();

        if (stateTimer < 0){
            stateMachine.ChangeState(player.stateAir);
        }

        if (player.IsGroundDetected()){
            stateMachine.ChangeState(player.stateIdle);
        }
    }

    public override void Exit() {
        base.Exit();
    }

}