using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill:MonoBehaviour{
    [SerializeField] protected float cooldownSkill;
    protected float cooldownTimer;

    protected void Update(){
        cooldownTimer-=Time.deltaTime;
        cooldownTimer %= 100;
    }

    public virtual bool CanUseSkill(){
        if (cooldownTimer<0){
            UseSkill();
            cooldownTimer=cooldownSkill;
            return true;
        }
        Debug.Log("Skill is on cooldown");
        return false;
    }

    public virtual void UseSkill(){
        //TODO: skill dash
    }
    
}