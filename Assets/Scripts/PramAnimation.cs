using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PramAnimation : MonoBehaviour
{
    public float tiltAmount = 30f;
    public float movementSpeed = 5f;
    public float moveUpAmount = 1f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Transform childTransform;
    private float originalRotation;
    private bool isMovingUp;
    private bool isGrounded;
    private Rigidbody2D rb;

    private void Start()
    {
        // Assuming the child object is the first child of the game object
        childTransform = transform.GetChild(0);
        originalRotation = childTransform.rotation.eulerAngles.z;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            // Move the object horizontally
            transform.Translate(Vector3.right * horizontalInput * movementSpeed * Time.deltaTime);

            // Calculate the target rotation based on the input
            float targetRotation = originalRotation - tiltAmount * horizontalInput;

            // Apply the rotation to the child object
            childTransform.rotation = Quaternion.Euler(0f, 0f, targetRotation);
        }
        else
        {
            // Reset the rotation when there is no input
            childTransform.rotation = Quaternion.Euler(0f, 0f, originalRotation);
        }

        // Check if the ground is touched
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Start moving the child object up
                Jump();
            }
        }

        if (isMovingUp)
        {
            // Move the child object up
            childTransform.Translate(Vector3.up * moveUpAmount * Time.deltaTime);

            // Check if the child object has moved up by the desired amount
            if (childTransform.localPosition.y >= moveUpAmount)
            {
                // Start moving the child object back down
                isMovingUp = false;
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isMovingUp = true;
    }
}
