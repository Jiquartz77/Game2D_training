using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SkillCloneController : MonoBehaviour {

    [SerializeField] private float fadeSpeed;

    Player player;
    SpriteRenderer sr;
    private float cloneTimer;

    private void Awake(){
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update(){
        cloneTimer -= Time.deltaTime; cloneTimer %= 100;

        if (cloneTimer < 0){
            sr.color = new Color(1,1,1, sr.color.a - Time.deltaTime * fadeSpeed);
        }
    }
    public void SetupClone(Transform _new, float _cloneDuration){
        transform.position = _new.position;
        cloneTimer = _cloneDuration;
    }
}
