using UnityEngine;
using System.Collections;


public class ExampleClass : MonoBehaviour {
    [SerializeField]
    private float speed = 10.0f;
    public float jumpForce = 10.0f;
    public float rotationSpeed = 100.0f;
    public float xInput ;
    public float yInput ;
    public Rigidbody2D rb;

    float horizontalSpeed = 12.0f;
    float verticalSpeed = 12.0f;

    void Start() {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        //transform.position = new Vector3(transform.position.x + xInput * verticalSpeed * Time.deltaTime, 
        //transform.position.y, transform.position.z);
        Move();
    }

    void Move(){
        if (Input.GetButton("Horizontal")){
            rb.velocity = new Vector2 (xInput* horizontalSpeed, rb.velocity.y);
        }
        else if (Input.GetKeyDown(KeyCode.Space)){
            //rb.AddForce(new Vector2(0, jumpForce));
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
        }
    }
}