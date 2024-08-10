using System.Data.Common;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState {

    public PlayerPrimaryAttack(PlayerStateMachine stateMachine, Player player, string animBoolName) : 
    base(stateMachine, player, animBoolName) { }

    private int comboCounter =0;
    private float comboTimeWindow =0.9f;
    private float lastAttackTime ;
    private readonly int attackNum =3;

    public override void Enter() {
        base.Enter();

        comboCounter%= attackNum;
        if (Time.time >= lastAttackTime + comboTimeWindow){
            comboCounter = 0;
        }

        player.anim.SetInteger("comboCounter", comboCounter);

        float attackDirection = player.facingDirection;
        if (xInput > float.Epsilon || xInput < -float.Epsilon){
            attackDirection = xInput;
        }

        player.SetVelocity(player.attackMovement[comboCounter].x * attackDirection,
         player.attackMovement[comboCounter].y);

        stateTimer =0.1f;

    }

    public override void Update() {
        base.Update();

        if (stateTimer < 0){
            player.SetVelocityZero();
        }

        if (triggerCalled){
            stateMachine.ChangeState(player.stateIdle);
        }
    }

    public override void Exit() {
        base.Exit();

        //prevent from IdleState
        player.StartCoroutine("BusyFor", .15f);

        comboCounter++;
        lastAttackTime = Time.time;
    }
}
