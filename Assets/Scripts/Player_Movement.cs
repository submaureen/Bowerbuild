using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rigidboy;
    private float horizontalInput;

    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump")) {
            rigidboy.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
        
    }

    private void FixedUpdate () {
        Move();
    }
    

    void Move() {
        rigidboy.AddForce(Vector2.right * horizontalInput * acceleration);
        Vector2 clampedVelocity = rigidboy.velocity;
        clampedVelocity.x = Mathf.Clamp(rigidboy.velocity.x, -maxSpeed, maxSpeed);
        rigidboy.velocity = clampedVelocity;
    }
}
