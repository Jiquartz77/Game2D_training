using UnityEngine;

public class PlayerStateDash : PlayerState {
    public PlayerStateDash(PlayerStateMachine stateMachine, Player player, string animBoolName) : 
    base(stateMachine, player, animBoolName) { }

    public override void Enter() {
        base.Enter();
        stateTimer=player.dashDuration;
        
        player.SetVelocity(player.inputDirection * player.dashSpeed, 0);
    }

    public override void Update() {
        base.Update();

        player.SetVelocity(rb.velocity.x, 0);

        if (player.IsWallDetected()){
            stateMachine.ChangeState(player.stateWallSlide);
            return;
        }

        if (stateTimer < 0){
            if (!player.IsGroundDetected()){
                stateMachine.ChangeState(player.stateAir);
            }
            else{
            stateMachine.ChangeState(player.stateIdle);
            }
        }
    }

    public override void Exit() {
        base.Exit();
        player.SetVelocity(0, rb.velocity.y);
    }
}
