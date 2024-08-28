using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField]
    private float speed;
    private float moveInput;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask isInGround;
    [SerializeField]
    private Transform groundController;
    [SerializeField]
    private Vector3 boxDimension;

    public bool isGrounded;
    private bool facingRight = true;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
            moveInput = Input.GetAxis("Horizontal");

            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            }
            if (moveInput > 0 && !facingRight)
            {
                Flip();
            }
            else if (moveInput < 0 && facingRight)
            {
                Flip();
            }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundController.position, boxDimension, 0f, isInGround);
        rb2D.velocity = new Vector2(moveInput * speed, rb2D.velocity.y);
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(groundController.position, boxDimension);
    }
}
