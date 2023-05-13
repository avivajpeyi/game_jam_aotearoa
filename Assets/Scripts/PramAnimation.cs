using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PramAnimation : MonoBehaviour
{
    public float tiltAmount = 30f;
    public float moveUpAmount = 1f;

    private Transform pramBody;
    private Transform pramWheels;
    private float originalRotation;
    private bool isMovingUp;
    public float pramBodyOffset = 1f;

    private void Start()
    {
        // // get child "body" transform by name
        pramBody = transform.Find("body");
        pramWheels = transform.Find("WheelBase");
        originalRotation = pramBody.rotation.eulerAngles.z;
    }

    private void Update()
    {
        if (GameManager.is3D)
            Handle3dAnim();
        else
            Handle2dAnim();
    }


    void Handle3dAnim()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            float targetRotation = originalRotation - tiltAmount * horizontalInput;
            pramBody.rotation = Quaternion.Euler(0f, 0f, targetRotation);
        }
        else
        {
            // Reset the rotation when there is no input
            pramBody.rotation = Quaternion.Euler(0f, 0f, originalRotation);
        }
    }

    void Handle2dAnim()
    {
        if (PlayerController.isGrounded)
        {
            // Reset the rotation when there is no input
            pramBody.rotation = Quaternion.Euler(0f, 0f, originalRotation);
            pramWheels.rotation = Quaternion.Euler(0f, 0f, 0f);
            // reset the body position
            pramBody.position = new Vector3(
                pramBody.position.x,
                pramWheels.position.y + pramBodyOffset,
                pramBody.position.z
                );
        }
        else
        {
            // move the body up 
            pramBody.position += Vector3.up * moveUpAmount * Time.deltaTime;
            // rorate the body along the x axis back 10 degrees
            pramBody.rotation = Quaternion.Euler(-10f, 0f, originalRotation);

            // rotate the wheels off -10 degrees
            pramWheels.rotation = Quaternion.Euler(-5f, 0f, 0f);
        }
    }
}