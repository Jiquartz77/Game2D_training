using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    void Start() {
    }

    void Update() {
    }

    public void ExitGame() {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
