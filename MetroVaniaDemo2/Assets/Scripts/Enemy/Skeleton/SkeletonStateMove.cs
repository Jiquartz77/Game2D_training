using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateMove : SkeletonStateGround
{
    public SkeletonStateMove(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : 
    base(enemyBase, stateMachine, animBoolName, enemy) { 
    }

    public override void Enter() {
        base.Enter();
    }

    public override void Update() {
        base.Update();
        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDirection, 0);

        if (enemy.IsWallDetected() || !enemy.IsGroundDetected()) {
            stateMachine.ChangeState(enemy.stateIdle);
            enemy.Flip();
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
