using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvents : MonoBehaviour
{
    private Player player; 

    void Start() {
        player = GetComponentInParent<Player>();
    }

    private void AnimationTrigger() {
        player.AttackEnd();
    }
}
