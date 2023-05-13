using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PramAnimation : MonoBehaviour
{
    public float tiltAmount = 30f;
    public float moveUpAmount = 1.5f;

    private Transform pramBody;
    private Transform pramWheels;
    private float originalRotation;
    private bool isMovingUp;
    public float pramBodyOffset = 1f;
    bool isFrozen = false;

    private PlayerController _playerController;
    private void Start()
    {
        pramBody = transform.Find("body");
        pramWheels = transform.Find("WheelBase");
        originalRotation = pramBody.rotation.eulerAngles.z;
        _playerController = FindObjectOfType<PlayerController>();
        ScriptableEvents.endGame += Freeze;
    }

    private void OnDestroy()
    {
        ScriptableEvents.endGame -= Freeze;
    }

    private void Update()
    {
        if (isFrozen)
            return;

        if (GameManager.is3D)
            Handle3dAnim();
        else
            Handle2dAnim();
    }


    void Freeze()
    {
        isFrozen = true;
    }


    void Handle3dAnim()
    {
        
        if (_playerController.horizontalInput != 0)
        {
            // if (!PlayerController.canMoveLeft && _playerController.horizontalInput < 0)
            // {
            //     horizontalInput = 0;
            // }
            // else if (!PlayerController.canMoveRight && horizontalInput > 0)
            // {
            //     horizontalInput = 0;
            // }

            float targetRotation = originalRotation - tiltAmount * _playerController.horizontalInput;
            pramBody.rotation = Quaternion.Euler(0f, 0f, targetRotation);
        }
        else
            IdlePos();
    }

    void Handle2dAnim()
    {
        if (PlayerController.isGrounded)
        {
            IdlePos();
        }
        else
        {
            pramBody.rotation = Quaternion.Euler(-10f, 0f, originalRotation);
            pramWheels.rotation = Quaternion.Euler(-5f, 0f, 0f);
            pramBody.position += moveUpAmount * Time.deltaTime * Vector3.up;
        }
    }

    void IdlePos()
    {
        pramBody.rotation = Quaternion.Euler(0f, 0f, originalRotation);
        pramWheels.rotation = Quaternion.Euler(0f, 0f, 0f);
        pramBody.position = new Vector3(
            pramBody.position.x,
            pramWheels.position.y + pramBodyOffset,
            pramBody.position.z
        );
    }
}