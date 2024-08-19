using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateGround : EnemyState
{
    protected EnemySkeleton enemy;

    public SkeletonStateGround(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton _enemy) : 
    base(enemyBase, stateMachine, animBoolName) { 
        this.enemy = _enemy;
    }
    
    public override void Enter() {
        base.Enter();
    }

    public override void Update() {
        base.Update();

        if (enemy.IsPlayerDetected() || enemy.IsPlayerDetected().distance > enemy.playerDistanceAttack){
            stateMachine.ChangeState(enemy.stateNotice);
        }

    }

    public override void Exit() {
        base.Exit();
    }
}
