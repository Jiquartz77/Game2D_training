using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateIdle : SkeletonStateGround
{
    public SkeletonStateIdle(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : 
    base(enemyBase, stateMachine, animBoolName, enemy) {
    }

    public override void Enter() {
        base.Enter();
        stateTimer = enemy.timeIdle;
    }

    public override void Update() {
        base.Update();

        if (stateTimer < 0){
            stateMachine.ChangeState(enemy.stateMove);
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
