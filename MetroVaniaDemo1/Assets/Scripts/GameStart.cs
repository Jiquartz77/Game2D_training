using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public GameObject LoadingScene;

    void Start() {
        //style
        myText.text = "Start Game"; 
        myText.color = Color.red; 
        myText.fontSize = 24; 
        myText.alignment = TextAlignmentOptions.Center; 
    }

    // Update is called once per frame
    void Update() {
    }

    public void StartGame() {
        LoadingScene.SetActive(true);
        //yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1); // SceneManager Class
    }
}
