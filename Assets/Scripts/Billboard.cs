using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private Transform cameraTransform;
    private Quaternion initialRotation;

    private void Start()
    {
        // Get the main camera's transform
        cameraTransform = mainCamera.transform;

        // Store the initial rotation of the object
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Calculate the rotation needed to face the camera
        // cameraTransform = mainCamera.transform;

        Vector3 targetPosition = transform.position - cameraTransform.position;
        Debug.Log("bill: transform = " + transform.position);


        targetPosition.y = 0f; // Lock rotation around the y-axis
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition, Vector3.up);
        Debug.Log("billboard: target location = " + targetRotation);

        // Apply the rotation only around the z-axis
        Vector3 eulerRotation = targetRotation.eulerAngles;
        eulerRotation.x = 90f;
        eulerRotation.y = 180f;
        eulerRotation.z = initialRotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
