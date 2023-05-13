using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWheel : MonoBehaviour
{
    float tiltAmount = 30f;
    float originalYRotation = 1f;
    public float speed = 500f;
    public bool turnLeftRight = false;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        originalYRotation = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        if (GameManager.is3D && turnLeftRight && _playerController.horizontalInput != 0)
        {
            float targetRotation = originalYRotation + tiltAmount * _playerController.horizontalInput;
            transform.rotation = Quaternion.Euler(0f, targetRotation, 0);
        }
        
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
        
    }
}