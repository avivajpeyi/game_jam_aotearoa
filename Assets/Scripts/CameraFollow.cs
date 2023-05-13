using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;
    Transform _player;

    

    public bool testMode; // public so we can change it in script 1 location

    [SerializeField] bool is3D = true;
    [SerializeField] private float lerpTime = 0.15f;

    // Positioning
    Vector3 offset3D;
    Vector3 rotation3D;
    [SerializeField] private Vector3 offset2D;
    [SerializeField] private Vector3 rotation2D = new Vector3(0, -90, 0);


    //  perspective section
    private Matrix4x4 perspective2d, perspective3d;
    [SerializeField] private float fov = 60f;
    [SerializeField] private float near = .3f;
    [SerializeField] private float far = 1000f;
    [SerializeField] private float orthographicSize = 5f;
    [SerializeField] private float aspect;


    private void Start()
    {
        cam = GetComponent<Camera>();
        _player = FindObjectOfType<PlayerController>().transform;
        InitialiseCameraData();
        if (_player == null)
            Debug.LogError("Player not found by Camera!");

        ScriptableEvents.eventActivate2D += SwitchTo2D;
        ScriptableEvents.eventActivate3D += SwitchTo3D;
    }

    public void OnDestroy()
    {
        ScriptableEvents.eventActivate2D -= SwitchTo2D;
        ScriptableEvents.eventActivate3D -= SwitchTo3D;
    }


    private void InitialiseCameraData()
    {
        is3D = true;
        // Set 3D positioning data by current camera position/rotation
        offset3D = transform.position - _player.position;
        rotation3D = transform.rotation.eulerAngles;
        aspect = (float)Screen.width / (float)Screen.height;
        UpdatePerspectiveData();
        cam.projectionMatrix = perspective3d;
    }

    void UpdatePerspectiveData()
    {
        perspective2d = Matrix4x4.Ortho(-orthographicSize * aspect,
            orthographicSize * aspect,
            -orthographicSize, orthographicSize, near, far);
        perspective3d = Matrix4x4.Perspective(fov, aspect, near, far);
    }

    public static Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
    {
        Matrix4x4 ret = new Matrix4x4();
        for (int i = 0; i < 16; i++)
            ret[i] = Mathf.Lerp(from[i], to[i], time);
        return ret;
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


        
    }

    public void SwitchTo3D()
    {
        is3D = true;
        // 
        Vector3 targetPos = new Vector3(
            offset3D.x,
            _player.position.y + offset3D.y,
            _player.position.z + offset3D.z
        );

        StartLerpCameraCoroutine(targetPos, rotation3D, perspective3d);
    }

    public void SwitchTo2D()
    {
        is3D = false;
        Vector3 targetPos = new Vector3(
            _player.position.x + offset2D.x,
            offset2D.y,
            _player.position.z + offset2D.z
        );

        StartLerpCameraCoroutine(targetPos, rotation2D, perspective2d);
    }

    private Coroutine StartLerpCameraCoroutine(Vector3 targetPos, Vector3 targetRot,
        Matrix4x4 targetPerspective)
    {
        StopAllCoroutines();
        return StartCoroutine(LerpCamera(targetPos, targetRot, targetPerspective));
    }


    private IEnumerator LerpCamera(
        Vector3 targetPos, Vector3 targetRot,
        Matrix4x4 targetPerspective)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;
        Matrix4x4 startPerspective = cam.projectionMatrix;
        while (time < lerpTime)
        {
            float dt = time / lerpTime;
            transform.position = Vector3.Lerp(startPosition, targetPos, dt);
            transform.rotation =
                Quaternion.Lerp(startRotation, Quaternion.Euler(targetRot), dt);
            cam.projectionMatrix = MatrixLerp(startPerspective, targetPerspective, dt);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        transform.rotation = Quaternion.Euler(targetRot);
        cam.projectionMatrix = targetPerspective;
    }
}