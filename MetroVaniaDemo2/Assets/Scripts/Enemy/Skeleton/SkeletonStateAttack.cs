using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateAttack : SkeletonStateGround
{
    //protected EnemySkeleton enemy;

    public SkeletonStateAttack(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton _enemy) : 
    base(enemyBase, stateMachine, animBoolName, _enemy) { 
        //this.enemy = _enemy;
    }
    
    public override void Enter() {
        base.Enter();
        enemy.SetVelocityZero();
        stateTimer = enemy.timeAttack;
    }

    public override void Update() {
        base.Update();

        if (stateTimer < 0){
            stateMachine.ChangeState(enemy.stateMove);
        }

        if (!enemy.IsPlayerDetected()){
            stateMachine.ChangeState(enemy.stateMove);
        }


    }

    public override void Exit() {
        base.Exit();
    }
}
