using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateNotice : SkeletonStateGround {

    protected int moveDir;
    private Transform player;

    public SkeletonStateNotice(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : 
    base(enemyBase, stateMachine, animBoolName, enemy) { 
    }

    public override void Enter() {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Update() {
        base.Update();
        if (player.position.x > enemy.transform.position.x){
            moveDir = 1;
        }
        else if (player.position.x < enemy.transform.position.x){
            moveDir = -1;
        }
        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
        
        if (!enemy.IsPlayerDetected()){
            stateMachine.ChangeState(enemy.stateIdle);
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
