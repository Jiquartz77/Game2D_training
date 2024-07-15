using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKill1 : MonoBehaviour {
    public float Skill_speed =1;
    public GameObject Rotation;
    public float deltaTime = 1f;

    void Start(){ }

    void Update(){
        Vector3 direction_vec;
        //if (Rotation.transform.position >= -1.1 && Rotation.transform.rotation < 181.1){
            direction_vec = new Vector3(1, 0, 0); // right
        //}else {
            direction_vec = new Vector3(-1, 0, 0); // to left
        //}
        transform.Translate(direction_vec * Skill_speed * deltaTime);
    }
}

