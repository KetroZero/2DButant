using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator playerAnimator;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    private void Start()
    {
        if (moveSpeed< 0)
        {
            moveSpeed = 0;
        }
    }

    // FixedUpdate is better than Update when using Rigidbody
    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        Vector3 direction = new Vector3(horizontal, vertical, 0);
        Move(direction);

        playerAnimator.SetFloat("horizontalSpeed", rb.velocity.x);
        playerAnimator.SetFloat("verticalSpeed", rb.velocity.y);
    }


    // Move character
    private void Move(Vector3 _velocity)
    {
        rb.velocity = Vector3.SmoothDamp(rb.velocity, _velocity, ref velocity, 0.05f);
    }
}
