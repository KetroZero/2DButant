using System;
using UnityEngine;

public class PlayerMoveSide : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    public Transform leftFoot;
    public Transform rightFoot;
    public bool isGrounded;

    private Vector3 velocity = Vector3.zero;
    private bool isJumping = false;


    // Start is called before the first frame update
    private void Start()
    {
        // Only positive value
        moveSpeed = Math.Abs(moveSpeed);
        jumpForce = Math.Abs(jumpForce);
    }

    // FixedUpdate is better than Update when using Rigidbody
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        MoveHorizontal(horizontal);

        isGrounded = Physics2D.OverlapArea(leftFoot.position, rightFoot.position);

        if (isGrounded)
        {
            isJumping = false;
        }

        if (Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0)
        {
            Jump(jumpForce);
        }
    }

    // Move character
    private void MoveHorizontal(float _movement)
    {
        Vector3 horizontal = new Vector3(_movement, rb.velocity.y, 0);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, horizontal, ref velocity, 0.05f);
    }

    private void Jump(float _jumpForce)
    {
        if (!isJumping)
        {
            rb.AddForce(Vector2.up * _jumpForce);
            isJumping = true;
        }
    }
}
