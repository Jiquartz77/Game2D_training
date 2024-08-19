using UnityEngine;

public class EnemyAnimationTriggers : MonoBehaviour {
    private Enemy enemy => GetComponentInParent<Enemy>();

    public void AnimationTrigger() {
        enemy.EnemyAnimationTrigger();
    }
}

