using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateGround : EnemyState
{
    EnemySkeleton enemy;

    public SkeletonStateGround(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton _enemy) : 
    base(enemyBase, stateMachine, animBoolName) { 
        this.enemy = _enemy;
    }
}
