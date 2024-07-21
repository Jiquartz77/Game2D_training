using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Location")]
    public GameObject LocationCenter;
    public GameObject LocationLeft;
    public GameObject LocationRight;
    public GameObject LocationTarget;

    public float DistanceCenter;
    public float DistanceEnemy;
    public float DistanceWalk;
    public float DistanceAttack;

    private GameObject Player;

    public float MoveSpeed = 2f;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        Distance();
        Move();
    }

    public void Distance() {
        DistanceEnemy= Vector3.Distance(transform.position, Player.transform.position);
        DistanceCenter = Vector3.Distance(Player.transform.position, LocationCenter.transform.position);
    }

    public void Move() {
        //LocationTarget = LocationLeft;
        Vector3 LocationEnd = LocationTarget.transform.position;
        LocationEnd.y = transform.position.y; //the same Y axis;
    
        //Move to the target
        transform.position = Vector2.MoveTowards(transform.position, LocationEnd,
         MoveSpeed * Time.deltaTime);
        
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
