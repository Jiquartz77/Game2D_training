using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpDetect : MonoBehaviour {

    [Header("Components")]
    public Animator CharacAniCon;

    private void OnTriggerStay2D(Collider2D other) {
        //if (other.tag== "Ground"){
        if (other.tag.Equals ("Ground")){
            CharacAniCon.SetBool("isJump", false);
            CharacAniCon.SetBool("isFloor", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
            CharacAniCon.SetBool("isJump", true);
            CharacAniCon.SetBool("isFloor", false);
    }

}
