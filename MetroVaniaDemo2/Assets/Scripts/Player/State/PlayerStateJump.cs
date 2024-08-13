using UnityEngine;

public class PlayerStateJump : PlayerStateAir
{

    public PlayerStateJump(PlayerStateMachine stateMachine, Player player, string animBoolName) 
    : base(stateMachine, player, animBoolName) {
    }
    
    public override void Enter() {
        base.Enter();

        player.SetVelocity( rb.velocity.x, player.jumpForce ); 
        //rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
    }

    public override void Update() {
        base.Update();

        if (rb.velocity.y< 0){
            stateMachine.ChangeState(player.stateAir);
        }

    }

    public override void Exit() {

        base.Exit();
    }
}

