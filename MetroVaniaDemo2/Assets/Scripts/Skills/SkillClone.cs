using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillClone: Skill{

    [SerializeField]private GameObject clonePrefab;
    [SerializeField]private float cloneDuration;

    public override void UseSkill(){
        base.UseSkill();
        //TODO: skill dash
    }

    public void CreateClone(Transform transform){
        GameObject newClone = Instantiate(clonePrefab);
        newClone.GetComponent<SkillCloneController>().SetupClone(transform, cloneDuration);
    }
    
}