
public class PlayerStateIdle : PlayerStateGround
{
    public PlayerStateIdle(PlayerStateMachine stateMachine, Player player, string animBoolName) 
    : base(stateMachine, player, animBoolName) {
    }
    
    public override void Enter() {
        base.Enter();
    }

    public override void Update() {
        base.Update();
        if (xInput > float.Epsilon || xInput < -float.Epsilon){ // xInput != 0
            stateMachine.ChangeState(player.stateMove);
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
