using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyPatrol { Center, Left, Right };
public enum EnemyState {
    Patrol,
    MoveToPlayer,
    Attack,
    GetHit
};

public class EnemyController : MonoBehaviour
{
    [Header("Location")]
    public GameObject LocationCenter;
    public GameObject LocationLeft;
    public GameObject LocationRight;
    public GameObject LocationTarget;
    public Animator EnemyAni;

    public float DistanceCenter;
    public float DistanceEnemy;
    public float DistanceWalk;
    public float DistanceAttack;

    private GameObject Player;

    public float MoveSpeed = 2f;
    public EnemyState ZombieState = EnemyState.Patrol;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        Distance();
        if (ZombieState == EnemyState.Patrol){
            PatrolMove();
            if (DistanceCenter <= DistanceWalk){
                ZombieState = EnemyState.MoveToPlayer;
            }
        }
        else if (ZombieState == EnemyState.MoveToPlayer){
            //MoveToPlayer();
            if (DistanceEnemy <= DistanceAttack){
                ZombieState = EnemyState.Attack;
            }else if (DistanceEnemy > DistanceAttack){
                ZombieState = EnemyState.Patrol;
            }
        }
        else if (ZombieState == EnemyState.Attack){
        }
 }

    public void Distance() {
        //x-y
        DistanceEnemy= Vector3.Distance(transform.position, Player.transform.position);
        //DistanceCenter = Vector3.Distance(Player.transform.position, LocationCenter.transform.position);
    }

    public void PatrolMove() {
        //LocationTarget = LocationLeft;
        Vector3 LocationEnd = LocationTarget.transform.position;
        LocationEnd.y = transform.position.y; //the same Y axis;
    
        //Move to the target
        transform.position = Vector2.MoveTowards(transform.position, LocationEnd,
        MoveSpeed * Time.deltaTime);

        if (DistanceEnemy > 0){
            EnemyAni.SetBool("isRun", true);
        }
        
        // Rotation
        Vector3 EnemyDirection = (LocationEnd - transform.position).normalized;
        if (EnemyDirection.x > 0){
            //transform.rotation = Quaternion.LookRotation(EnemyDirection);
            transform.rotation = Quaternion.Euler(0, 0 , 0);
        }else if (EnemyDirection.x < 0 ){
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
};
