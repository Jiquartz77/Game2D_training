using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    [Header("Character")]
    public float speed =4.0f;
    public float jumpForce = 4.5f;
    public float AttackInterval = 0.8f;
    public float SKillRead = 0.8f;
    public float TeleportTime = 0.8f;
    public bool isAttack =false;
    public bool canAttack =true;
    public bool canSkill =true;
    public bool canSprint =true;

    [Header("Components")]
    public Rigidbody2D CharacRigid;
    public Animator CharacAniCon;
    public GameObject CharacModel;
    public GameObject AttackBox;
    public GameObject AttackLoc;

    void Start() {
        Application.targetFrameRate =60;
        Console.WriteLine("Hello World!");
    }
    // Update is called once per frame
    void Update() {
        Move();
        Jump();
        Attack();
        //Debug.Log("Speed: "+ parameters.speed);
        //Debug.Log("jumpF: "+ parameters.jumpForce);
    }
    #region Actions
    void Move(){
        float inputX= Input.GetAxisRaw("Horizontal");
        float inputY= Input.GetAxisRaw("Vertical");
        //float moveY =inputY * speed;

        //can't Move during Attack
        if (isAttack == true){
            inputX =0;
        }

        float moveX =inputX * speed;
        float moveY = CharacRigid.velocity.y;

        CharacRigid.velocity = new Vector2(moveX, moveY);
        CharacAniCon.SetFloat("RunBlend", Mathf.Abs(inputX)); //0 for Idle; None 0 for Run;
        if (inputX > 0){
            CharacModel.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputX < 0){
            CharacModel.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //else { CharacAniCon.SetBool("isRun", false); }
    }

    void Jump(){
       if (CharacAniCon.GetBool("isJump") ==false && Input.GetKeyDown(KeyCode.Space) == true){
            //CharacAniCon.SetBool("isJump", true);
            CharacRigid.velocity= new Vector2(CharacRigid.velocity.x, jumpForce);
        }
    }

    void Attack(){
        //0 for left-click
        if (canAttack ==true && isAttack == false) {
            if (Input.GetMouseButtonDown(0) == true || Input.GetKeyDown(KeyCode.Z) == true) {
                isAttack = true;
                canAttack =false;
                CharacAniCon.SetTrigger("attack");
                Invoke("AttackEnd", AttackInterval); // delay N seconds
            }

            else if (Input.GetKeyDown(KeyCode.X)==true){
                if (canSkill == true){
                    canAttack=false;
                    canSkill=false;
                    CharacAniCon.SetTrigger("SkillStart");
                    Invoke("SkillEnd", SKillRead);
                    AttackStart();
                    //SkillEffectStart();
                }
            }

            else if (Input.GetKeyDown(KeyCode.LeftShift)==true){
                if (canSprint == true){
                    canAttack=false;
                    canSkill=false;
                    CharacAniCon.SetTrigger("TeleportStart");
                    Invoke("TeleportStart", TeleportTime);
                    AttackStart();
                    //SprintStart();
                }
        }

    }

        #region AttackFunc
        void AttackEnd()
        {
            canAttack = true;
            isAttack = false;
        }

        void AttackStart() { isAttack = true; }

        void Attacking(){
            Instantiate(AttackBox, AttackLoc.transform.position, AttackLoc.transform.rotation);
        }
        #endregion

        /*
        #region  SkillFunc
            //public void SkillStart(){ canSkill =false; canAttack = false; }

            void SkillEnd(){
                Instantiate(SKillBox, SkillLocation.transform.position, SkillLocation.transform.rotation);
                CharacAniCon.SetTrigger("SkillStart");
                Invoke("SkillEnd", SkillRead);
            }

            public void SkillEffectStart(){ SkillEffect.setActive(true); }
            public void SkillEffectEnd(){ SkillEffect.setActive(false); }
        #endregion
        */

        #endregion
    }
};
