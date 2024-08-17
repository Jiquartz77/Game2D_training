using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStateIdle : EnemyState
{
    public SkeletonStateIdle(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : 
    base(enemyBase, stateMachine, animBoolName) { }
}
