using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    public EnemyStateMachine stateMachine{get; private set;}

    public readonly float playerDistanceNotice = 15f;
    public readonly float playerDistanceAttack = 5f;
    [SerializeField] protected LayerMask whatIsPlayer;
    public string lastAnimBoolName {get; private set;}

    protected override void Awake() {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
        stateMachine.currentState.Update();
    }

    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(transform.position, facingDirection * Vector2.right,
     playerDistanceNotice, whatIsPlayer);

    protected override void OnDrawGizmos() {
        base.OnDrawGizmos();
        Debug.DrawLine(transform.position, transform.position + facingDirection * playerDistanceNotice * Vector3.right, Color.red); // player detection
    }

    public virtual void EnemyAnimationTrigger() {
        stateMachine.currentState.AnimationFinishTrigger();
    }

    public virtual void AssignLastAnimName(string _animBoolName) => lastAnimBoolName = _animBoolName;
}
