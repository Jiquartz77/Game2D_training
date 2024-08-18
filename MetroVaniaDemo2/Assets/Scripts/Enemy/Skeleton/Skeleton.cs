using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySkeleton : Enemy {

    public SkeletonStateIdle stateIdle {get; private set;}
    public SkeletonStateMove stateMove {get; private set;}
    public SkeletonStateNotice stateNotice {get; private set;}

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float timeIdle = 0.8f;

    protected override void Awake() {
        base.Awake();
        stateIdle = new SkeletonStateIdle(this, stateMachine, "isIdle", this);
        stateMove = new SkeletonStateMove(this, stateMachine, "isMove", this);
        stateNotice = new SkeletonStateNotice(this, stateMachine, "isNotice", this);
    }

    protected override void Start() {
        base.Start();
        stateMachine.Initialize(stateIdle);
    }

    protected override void Update() {
        base.Update();
    }
}