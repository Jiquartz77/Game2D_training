using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateWallSlide : PlayerState
{
    public PlayerStateWallSlide(PlayerStateMachine stateMachine, Player player, string animBoolName) : 
    base(stateMachine, player, animBoolName) { }

    public override void Enter() {
        base.Enter();
    }

    public override void Update() {
    }

    public override void Exit() {
        base.Exit();
    }
}
