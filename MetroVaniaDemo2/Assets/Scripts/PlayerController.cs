using UnityEngine;
using System.Collections;


public class ExampleClass : MonoBehaviour {
    [SerializeField] private float horizontalSpeed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float rotationSpeed = 100.0f;
    [SerializeField] private float xInput ;
    [SerializeField] private float yInput ;
    
    private Rigidbody2D rb;
    private Animator player_AC;

    void Start() {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        player_AC = GetComponentInChildren<Animator>();
    }

    void Update() {
        xInput = Input.GetAxis("Horizontal");
        //yInput = Input.GetAxis("Vertical");
        CheckInput();
    }

    void CheckInput(){
        if (Input.GetButton("Horizontal")) {
            Movement();
        }
        else if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    private void Movement()
    {
        rb.AddForce(new Vector2(xInput * horizontalSpeed, rb.velocity.y));
        if (rb.velocity.x != 0)
        {
            player_AC.SetBool("isMoving", true);
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
        //rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
    }
}