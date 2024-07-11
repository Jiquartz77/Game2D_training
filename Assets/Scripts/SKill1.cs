using System.Collections;
using System.Collections.Generic;

public class SKill1 : MonoBehaviour {
    public float Skill_speed =1;
    public GameObject Rotation;

    void Start(){ }

    void Update(){
        if (Rotation.transform.rotation >=-1 && Rotation.transform.rotation < 181){
            Vector3 direction_vec = new Vector3(1, 0, 0); // right
        }else {
            Vector3 direction_vec = new Vector3(-1, 0, 0); // to left
        }
        transform.Translate(direction_vec * Skill_speed * deltaTime);
    }
}

