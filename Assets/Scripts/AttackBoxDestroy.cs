using System.Collections;
using System.Collections.Generic;

public class AttackBoxDestroy : MonoBehaviour {
    public float DestroyTime =1;

    void Start(){
        Destory(gameObject, DestroyTime);
    }
}

