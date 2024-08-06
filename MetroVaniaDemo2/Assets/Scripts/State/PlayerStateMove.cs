
using System.Data.Common;

public class PlayerStateMove : PlayerStateGround
{

    public PlayerStateMove(PlayerStateMachine stateMachine, Player player, string animBoolName) 
    : base(stateMachine, player, animBoolName) {
    }
    
    public override void Enter() {
        base.Enter();
    }

    public override void Update() {
        base.Update();

        player.SetVelocity(xInput * player.horizontalSpeed, rb.velocity.y); 

        if (player.IsGroundDetected()){
            //xIn ==0
            if (xInput < float.Epsilon && xInput> -float.Epsilon || player.IsWallDetected()){
                stateMachine.ChangeState(player.stateIdle);
            }
        }
        //player.SetVelocity(player.facingDirection * player.horizontalSpeed, rb.velocity.y); 
    }

    public override void Exit() {

        base.Exit();
    }
}

