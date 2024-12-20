using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDead : PlayerState {
    public PlayerStateDead(PlayerStateMachine stateMachine, Player player, string animBoolName) : 
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

    public override void AnimationFinishTrigger() {
        base.AnimationFinishTrigger();
    }
}
