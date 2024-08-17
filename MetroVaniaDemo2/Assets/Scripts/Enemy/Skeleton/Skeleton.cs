using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySkeleton : Enemy {

    SkeletonStateIdle stateIdle;
    SkeletonStateWalk stateWalk;
    //SkeletonStateReact stateReact;
    //SkeletonStateAttack stateAttack;

    protected override void Awake() {
        base.Awake();

        stateIdle = new SkeletonStateIdle(this, stateMachine, "isIdle");
        stateWalk = new SkeletonStateWalk(this, stateMachine, "isWalk");
    }

    protected override void Start() {
        stateMachine.Initialize(stateIdle);
        base.Start();
    }

    protected override void Update() {
        base.Update();
    }
}