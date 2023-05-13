using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PramAnimation : MonoBehaviour
{
    public float tiltAmount = 30f;
    public float moveUpAmount = 1f;

    private Transform childTransform;
    private float originalRotation;
    private bool isMovingUp;

    private void Start()
    {
        // // get child "body" transform by name
        childTransform = transform.Find("body");
            
        originalRotation = childTransform.rotation.eulerAngles.z;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            
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

}
