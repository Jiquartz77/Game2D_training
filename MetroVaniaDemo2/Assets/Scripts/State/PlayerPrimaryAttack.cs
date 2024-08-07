using UnityEditor;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    public PlayerPrimaryAttack(PlayerStateMachine stateMachine, Player player, string animBoolName) : 
    base(stateMachine, player, animBoolName) { }

    public override void Enter() {
        base.Enter();
    }

    public override void Update() {
        base.Update();

    }

    public override void Exit() {
        base.Exit();
    }
}
