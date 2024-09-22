using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateNotice : EnemyState {

    protected int moveDir;
    private Transform player;
    private EnemySkeleton enemy;

    public SkeletonStateNotice(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : 
    base(enemyBase, stateMachine, animBoolName) { 
        this.enemy = enemy;
    }

    public override void Enter() {
        base.Enter();
        player = GameObject.Find("Player").transform;
        stateTimer = enemy.timeNotice;
    }

    public override void Update() {
        base.Update();

        if (enemy.IsPlayerDetected()) {
            stateTimer = enemy.timeNotice;
            if (enemy.IsPlayerDetected().distance < enemy.playerDistanceAttack) {
                stateMachine.ChangeState(enemy.stateAttack);
            }
        }else{
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > enemy.distanceIgnore)
                stateMachine.ChangeState(enemy.stateIdle);
        }

        if (player.position.x > enemy.transform.position.x){
            moveDir = 1;
        }
        else if (player.position.x < enemy.transform.position.x){
            moveDir = -1;
        }

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }

    public override void Exit() {
        base.Exit();
    }
}
