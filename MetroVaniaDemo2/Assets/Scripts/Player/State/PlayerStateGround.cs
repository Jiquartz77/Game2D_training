using UnityEngine;

public class PlayerStateGround : PlayerState
{
    public PlayerStateGround(PlayerStateMachine stateMachine, Player player, string animBoolName) : 
    base(stateMachine, player, animBoolName) {
    }

    public override void Enter() {
        base.Enter();
        player.anim.SetBool("isGround", true);
    }

    public override void Update() {
        base.Update();

        if (! player.IsGroundDetected()){
            stateMachine.ChangeState(player.stateAir);
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected()) {
            stateMachine.ChangeState(player.stateJump);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0)){
            stateMachine.ChangeState(player.statePrimaryAttack);
        }
    }

    public override void Exit() {
        player.anim.SetBool("isGround", false);
        base.Exit();
    }
}
