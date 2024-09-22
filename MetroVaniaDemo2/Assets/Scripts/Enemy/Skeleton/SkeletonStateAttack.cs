using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateAttack : EnemyState
{
    protected EnemySkeleton enemy;

    public SkeletonStateAttack(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton _enemy) : 
    base(enemyBase, stateMachine, animBoolName) { 
        this.enemy = _enemy;
    }
    
    public override void Enter() {
        base.Enter();
        stateTimer = enemy.timeAttack;
    }

    public override void Update() {
        base.Update();

        //if (stateTimer < 0){ stateMachine.ChangeState(enemy.stateMove); }
        //if (!enemy.IsPlayerDetected()){ stateMachine.ChangeState(enemy.stateMove); }
        
        enemy.SetVelocityZero();
        if (triggerCalled){
            stateMachine.ChangeState(enemy.stateNotice);
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
