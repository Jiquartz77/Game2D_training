using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {
    public static SkillManager instance;

    public SkillDash dash {get; private set;}
    public SkillClone clone {get; private set;}

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
        dash = GetComponent<SkillDash>();
        clone = GetComponent<SkillClone>();
    }
}
