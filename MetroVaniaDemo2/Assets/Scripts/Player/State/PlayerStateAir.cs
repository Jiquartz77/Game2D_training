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


        //vY ==0

        //if (rb.velocity.y < float.Epsilon && rb.velocity.y > -float.Epsilon && player.IsGroundDetected()) {
        if (player.IsWallDetected())
            stateMachine.ChangeState(player.stateWallSlide);

        if(player.IsGroundDetected())
            stateMachine.ChangeState(player.stateIdle);

        if (xInput != 0) 
            player.SetVelocity(player.horizontalSpeed * .8f * xInput, rb.velocity.y);
    }

    public override void Exit() {
        base.Exit();
    }
}
