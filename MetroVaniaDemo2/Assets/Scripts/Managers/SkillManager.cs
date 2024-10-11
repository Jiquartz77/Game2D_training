using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {
    public static SkillManager instance;

    public Skill_Dash skillDash {get; private set;}

    //SingleTon
    private void Awake() {
        if (instance != null) {
            Destroy(instance.gameObject);
        }
        else {
            instance = this;
        }
    }

    private void Start() {
        skillDash = GetComponent<Skill_Dash>();
    }
}
