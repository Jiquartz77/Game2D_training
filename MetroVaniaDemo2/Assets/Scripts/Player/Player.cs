using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player :Entity{
    [Header("Attack")]
    public Vector2[] attackMovement;

    #region "States"
    public PlayerStateMachine stateMachine{get; private set;}
    public PlayerStateIdle stateIdle{get; private set;}
    public PlayerStateMove stateMove{get; private set;}
    public PlayerStateJump stateJump{get; private set;}
    public PlayerStateAir stateAir{get; private set;}
    public PlayerStateDash stateDash{get; private set;}
    public PlayerStateWallSlide stateWallSlide{get; private set;}
    public PlayerStateWallJump stateWallJump{get; private set;}
    public PlayerStateDead stateDead {get; private set;}
    public PlayerPrimaryAttack statePrimaryAttack {get; private set;}
    #endregion
    
    public bool isBusy {get; private set;}
    
    [Header("Movement")]
    public readonly float horizontalSpeed =8f;
    public readonly float dashSpeed = 15f;
    public readonly float wallSlideRatio =0.8f;
    public readonly float dashDuration = 0.6f;
    public readonly float dashCooldown = 1.2f;
    public readonly float wallJumpDuration = 0.4f;
    public readonly float wallJumpSpeed = 7f;
    protected float dashCooldownTimer = 0f;
    public float jumpForce = 25.0f;
    public float vX ;
    public float vY ;
    public float inputDirection {get; private set;}

    protected override void Awake() {
        base.Awake();

        Application.targetFrameRate =90;
        Debug.unityLogger.logEnabled = true;

        stateMachine =new PlayerStateMachine();
        stateIdle = new PlayerStateIdle(stateMachine, this, "isIdle"); 
        stateMove = new PlayerStateMove(stateMachine, this, "isMove"); 
        stateJump = new PlayerStateJump(stateMachine, this, "isJump"); 
        stateAir = new PlayerStateAir(stateMachine, this, "isAir"); 
        stateDash = new PlayerStateDash(stateMachine, this, "isDash"); 
        stateWallSlide = new PlayerStateWallSlide(stateMachine, this, "isWallSlide"); 
        stateWallJump = new PlayerStateWallJump(stateMachine, this, "isJump"); 
        stateDead = new PlayerStateDead(stateMachine, this, "isDead"); 
        statePrimaryAttack = new PlayerPrimaryAttack(stateMachine, this, "isAttack");

    }

    protected override void Start() {
        base.Start();
        stateMachine.Initialize(stateIdle);
    }

    protected override void Update() {
        base.Update();

        vX=rb.velocity.x; vY=rb.velocity.y;  // show velocity

        stateMachine.currentState.Update();
        CheckInput();
    }

    public override void Die() {
        base.Die();
        stateMachine.ChangeState(stateDead);
    }

    public IEnumerator BusyFor(float time){
        isBusy = true;
        yield return new WaitForSeconds(time);
        isBusy = false;
    }

    private void CheckInput(){
        //dashCooldownTimer -=Time.deltaTime;
        //dashCooldownTimer %= 100;

        //dash
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            inputDirection = Input.GetAxisRaw("Horizontal") ;

            //if inputDirection==0
            if (inputDirection <float.Epsilon && inputDirection > -float.Epsilon){
                inputDirection =facingDirection;
            }
            //if (dashCooldownTimer< 0){
            if (SkillManager.instance.dash.CanUseSkill()){
                //dashCooldownTimer = dashCooldown;
                stateMachine.ChangeState(stateDash);
            }
        }
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}