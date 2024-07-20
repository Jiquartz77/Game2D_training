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
    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
    }

    public void Distance() {
        DistanceEnemy= Vector3.Distance(transform.position, Player.transform.position);
        DistanceCenter = Vector3.Distance(Player.transform.position, LocationCenter.transform.position);
    }

    public void Move() {
    }
};
