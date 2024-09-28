using UnityEngine;

public class EnemyAnimationTriggers : MonoBehaviour {
    private Enemy enemy => GetComponentInParent<Enemy>();

    public void AnimationTrigger() {
        enemy.EnemyAnimationTrigger();
    }

    private void AttackTrigger() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);

        foreach (var hit in colliders) {
            if (hit.GetComponent<Player>() != null){
                hit.GetComponent<Player>().Damage();
            }
        }
    }
}

