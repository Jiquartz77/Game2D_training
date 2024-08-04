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

        if (Input.GetKeyDown(KeyCode.Space)) {
            stateMachine.ChangeState(player.stateJump);
        }
    }

    public override void Exit() {
        player.anim.SetBool("isGround", false);
        base.Exit();
    }
}
