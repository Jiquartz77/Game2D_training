using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateWalk : EnemyState
{
    public SkeletonStateWalk(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : 
    base(enemyBase, stateMachine, animBoolName) { }
}
