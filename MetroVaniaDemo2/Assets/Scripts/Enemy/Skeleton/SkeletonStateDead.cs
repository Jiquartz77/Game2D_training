using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateDead : EnemyState {
    protected EnemySkeleton enemy;

    public SkeletonStateDead(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton _enemy) : 
    base(enemyBase, stateMachine, animBoolName) { 
        this.enemy = _enemy;
    }

    public override void Enter() {
        base.Enter();
        enemy.anim.SetBool(enemy.lastAnimBoolName, true);
        enemy.anim.speed =0;
        enemy.cd.enabled = false;

        stateTimer = 0.1f;
    }

    public override void Update() {
        base.Update();
        if (stateTimer > 0){
            rb.velocity = new Vector2(0, 4); //Mario Dead
        }
    }
}