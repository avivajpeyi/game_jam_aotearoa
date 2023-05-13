using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltOnMovement : MonoBehaviour
{
    public float tiltAmount = 30f;
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float bounceHeight = 0.5f;
    public int bounceCount = 2;
    public float bounceDuration = 0.2f;

    private Transform childTransform;
    private float originalRotation;
    private bool isJumping = false;

    private void Start()
    {
        // Assuming the child object is the first child of the game object
        childTransform = transform.GetChild(0);
        originalRotation = childTransform.rotation.eulerAngles.z;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            // Perform jump action
            Jump();
        }

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
    }

    private void Jump()
    {
        isJumping = true;

        // Apply jump force to the object
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // Start the bouncing coroutine
        StartCoroutine(BounceCoroutine());
    }

    private IEnumerator BounceCoroutine()
    {
        int bounces = 0;

        while (bounces < bounceCount)
        {
            float startY = transform.position.y;
            float targetY = startY + bounceHeight;

            // Move the object upwards
            while (transform.position.y < targetY)
            {
                yield return null;
            }

            // Move the object downwards
            while (transform.position.y > startY)
            {
                yield return null;
            }

            bounces++;
        }

        isJumping = false;
    }
}

