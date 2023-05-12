using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;
    Transform _player;
    [SerializeField] Vector3 offset3D;
    // Rotation3d
    [SerializeField] Vector3 rotation3D;
    
    
    // Rotation2d

    [SerializeField]
    private Vector3 offset2D;

    [SerializeField] private Vector3 rotation2D = new Vector3(0, -90, 0);
    
    public bool testMode; // public so we can change it in script 1 location

    
    bool is3D = true;

    private void Start()
    {
        cam = GetComponent<Camera>();
        _player = FindObjectOfType<PlayerController>().transform;
        // if offset is not set, set it to the current position of the camera
        if (offset3D == Vector3.zero)
        {
            offset3D = transform.position - _player.position;
            rotation3D = transform.rotation.eulerAngles;
        }
            
        
        if (_player == null)
            Debug.LogError("Player not found by Camera!");
    }

    private void Update()
    {
        if (is3D)
        {
            Vector3 targetPos = _player.position + offset3D;
            targetPos.x = offset3D.x;
            transform.position = targetPos;
        }
        else
        {
            Vector3 targetPos = _player.position + offset2D;
            targetPos.y = offset2D.y;
            transform.position = targetPos;
        }


        if (testMode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3)) // the 3 key
            {
                SwitchTo3D();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchTo2D();
            }
        }

    }
    
    public void SwitchTo3D()
    {
        is3D = true;
        LerpCamera(offset3D, rotation3D);
        cam.orthographic = false;
    }
    
    public void SwitchTo2D()
    {
        is3D = false;
        LerpCamera(offset2D, rotation2D);
        // set the camera to orthographic
        cam.orthographic = true;
    }
    
    
    private void LerpCamera(Vector3 targetPos, Vector3 targetRot)
    {
        // smooth transition to target position
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
        // smooth transition to target rotation
        // Set the rotation of the camera to the target rotation
        transform.rotation = Quaternion.Euler(targetRot);
        // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRot), 0.1f);
    }
}