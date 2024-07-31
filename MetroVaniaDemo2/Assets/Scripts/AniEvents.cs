using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvents : MonoBehaviour
{
    private PlayerController player; 

    void Start() {
        player = GetComponentInParent<PlayerController>();
    }

    private void AnimationTrigger() {
        player.AttackEnd();
    }
}
