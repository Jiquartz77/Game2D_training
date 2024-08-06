using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateWallSlide : PlayerState
{
    public PlayerStateWallSlide(PlayerStateMachine stateMachine, Player player, string animBoolName) : 
    base(stateMachine, player, animBoolName) { }

    public override void Enter() {
        base.Enter();
    }

    public override void Update() {
        base.Update();

        if (player.IsGroundDetected()) {
            stateMachine.ChangeState(player.stateIdle);
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            stateMachine.ChangeState(player.stateWallJump);
            return ;
        }

        if (!player.IsWallDetected()) {
            stateMachine.ChangeState(player.stateAir);
        }

        //isWall && !isGround
        if (yInput < 0){
            player.SetVelocity(0, rb.velocity.y);
        }else{
            player.SetVelocity(0, rb.velocity.y * player.wallSlideRatio);
        }

        //xInput != 0
        if (xInput > float.Epsilon || xInput < -float.Epsilon) {
            if ((xInput < 0) && (player.facingDirection > 0) || (xInput > 0) && (player.facingDirection < 0)) {
                stateMachine.ChangeState(player.stateAir);
            }
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
