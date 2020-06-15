using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rigidboy;
    private float horizontalInput;
    public Animator animator;

    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float acceleration;

    private Vector3 scale;

    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        
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

    private void Flip () {


    }
    


    void Move() {
        if ((horizontalInput * transform.localScale.x) < 0) {
            scale.x *= -1;
            transform.localScale = scale;
        }
        animator.SetFloat("speed", Mathf.Abs(rigidboy.velocity.x));
        rigidboy.AddForce(Vector2.right * horizontalInput * acceleration);
        Vector2 clampedVelocity = rigidboy.velocity;
        clampedVelocity.x = Mathf.Clamp(rigidboy.velocity.x, -maxSpeed, maxSpeed);
        rigidboy.velocity = clampedVelocity;
    }
}
