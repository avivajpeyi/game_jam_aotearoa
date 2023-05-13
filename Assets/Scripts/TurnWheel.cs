using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWheel : MonoBehaviour
{
    float tiltAmount = 30f;
    float originalYRotation = 1f;
    float speed = 20f;


    private void Start()
    {
        originalYRotation = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (GameManager.is3D && horizontalInput != 0)
        {
            float targetRotation = originalYRotation + tiltAmount * horizontalInput;
            transform.rotation = Quaternion.Euler(0f, targetRotation, 0);
        }
        else
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
        
    }
}