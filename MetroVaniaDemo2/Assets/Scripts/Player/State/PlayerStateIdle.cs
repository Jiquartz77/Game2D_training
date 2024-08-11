
public class PlayerStateIdle : PlayerStateGround
{
    public PlayerStateIdle(PlayerStateMachine stateMachine, Player player, string animBoolName) 
    : base(stateMachine, player, animBoolName) {
    }
    
    public override void Enter() {
        base.Enter();
        player.SetVelocity(0, 0);
    }

    public override void Update() {
        base.Update();

        //xInput == facingDirection
        if ((xInput >0 && player.facingDirection > 0) || (xInput < 0 && player.facingDirection < 0)){
            if (player.IsWallDetected()){
                return ;
            }
        }

        if (xInput > float.Epsilon || xInput < -float.Epsilon){ // xInput != 0
            stateMachine.ChangeState(player.stateMove);
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
