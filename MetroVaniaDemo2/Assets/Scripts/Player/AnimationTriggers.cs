using UnityEngine;

public class AnimationTriggers : MonoBehaviour {
    private Player player => GetComponentInParent<Player>();

    public void AnimationTrigger() {
        player.AnimationTrigger();
    }
}
