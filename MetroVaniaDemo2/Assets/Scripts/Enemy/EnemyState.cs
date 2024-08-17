using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState {
    protected Enemy enemyBase;
    protected EnemyStateMachine stateMachine;
    protected Rigidbody2D rb;

    protected float stateTimer;

    protected bool triggerCalled;
    private string animBoolName;

    public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine,
     string animBoolName) {

        this.enemyBase = enemyBase;
        this.animBoolName = animBoolName;
        this. stateMachine = stateMachine;
    }

    public virtual void Enter() {
        triggerCalled =false;
        rb = enemyBase.rb;
        enemyBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Update() {
        stateTimer -= Time.deltaTime;
    }
    
    public virtual void Exit() {
        triggerCalled =true;
        enemyBase.anim.SetBool(animBoolName, true);
    }
}
