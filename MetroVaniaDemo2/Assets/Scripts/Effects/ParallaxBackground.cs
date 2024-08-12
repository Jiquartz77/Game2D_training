using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrallaxBackground : MonoBehaviour {
    private GameObject mainCamera;
    [SerializeField] private float parallaxEffect;

    private float xPosition;
    private float length;

    void Start() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        xPosition = transform.position.x;

        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update() {
        float distanceToMove = mainCamera.transform.position.x * parallaxEffect;
        float distanceMoved = mainCamera.transform.position.x - distanceToMove;

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

        if (distanceMoved > xPosition + length || distanceMoved < xPosition - length){
            xPosition += length;
        }

    }
}
