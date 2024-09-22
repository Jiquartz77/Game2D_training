using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySkeleton : Enemy {

    public SkeletonStateIdle stateIdle {get; private set;}
    public SkeletonStateMove stateMove {get; private set;}
    public SkeletonStateNotice stateNotice {get; private set;}
    public SkeletonStateAttack stateAttack {get; private set;}

    [Header("Movement")]
    public float moveSpeed = 2f;
    public readonly float timeIdle = 0.8f;
    public readonly float timeAttack = 0.8f;
    public readonly float timeNotice = 0.8f;
    public readonly float distanceIgnore = 8f;
    public readonly float distanceNotice = 5f; 

    protected override void Awake() {
        base.Awake();
        stateIdle = new SkeletonStateIdle(this, stateMachine, "isIdle", this);
        stateMove = new SkeletonStateMove(this, stateMachine, "isMove", this);
        stateNotice = new SkeletonStateNotice(this, stateMachine, "isNotice", this);
        stateAttack = new SkeletonStateAttack(this, stateMachine, "isAttack", this);
    }

    protected override void Start() {
        base.Start();
        stateMachine.Initialize(stateIdle);
    }

    protected override void Update() {
        base.Update();
    }
}