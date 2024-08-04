//using UnityEngine;

public class PlayerStateAir : PlayerState
{
    public PlayerStateAir(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName) {
    }

    public override void Enter() {
        base.Enter();
    }

    public override void Update() {
        base.Update();

        if (rb.velocity.y <= float.Epsilon && rb.velocity.y >= -float.Epsilon) {
            stateMachine.ChangeState(player.stateIdle);
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
