//using UnityEngine;

using UnityEngine;

public class PlayerStateAir : PlayerState
{
    public PlayerStateAir(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName) {
    }

    public override void Enter() {
        base.Enter();
    }

    public override void Update() {
        base.Update();

        player.SetVelocity(xInput * player.horizontalSpeed * 0.8f, rb.velocity.y);

        //vY ==0
        if (rb.velocity.y <= float.Epsilon && rb.velocity.y >= -float.Epsilon && player.IsGroundDetected()) {
            stateMachine.ChangeState(player.stateIdle);
        }
        else if (player.IsWallDetected() ){
            Debug.Log("wall detected");

            if ((xInput>0)&&(player.facingDirection>0) || (xInput<0)&&(player.facingDirection<0)){
                stateMachine.ChangeState(player.stateWallSlide);
            }
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
