using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraPerspectiveChanger : MonoBehaviour
{
    Camera cam;


    private bool testMode = false;

    private void Start()
    {
        cam = Camera.main;
        InitialisePerspectiveData();
    }
    
    //  perspective section
    private Matrix4x4 ortho, perspective;
    [SerializeField] private float fov = 60f;
    [SerializeField] private float near = .3f;
    [SerializeField] private float far = 1000f;
    [SerializeField] private float orthographicSize = 5f;
    [SerializeField] private float aspect;
    [SerializeField] private bool orthoOn;




    private void InitialisePerspectiveData()
    {
        aspect = (float)Screen.width / (float)Screen.height;
        UpdatePerspective();
        UpdateOrtho();
        cam.projectionMatrix = perspective;
        orthoOn = false;
    }

    void UpdateOrtho()
    {
        ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect,
            -orthographicSize, orthographicSize, near, far);
    }

    void UpdatePerspective()
    {
        perspective = Matrix4x4.Perspective(fov, aspect, near, far);
    }


    public static Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
    {
        Matrix4x4 ret = new Matrix4x4();
        for (int i = 0; i < 16; i++)
            ret[i] = Mathf.Lerp(from[i], to[i], time);
        return ret;
    }

    private IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, float duration)
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            cam.projectionMatrix = MatrixLerp(src, dest, (Time.time - startTime) /
                                                         duration);
            yield return 1;
        }

        cam.projectionMatrix = dest;
    }

    private Coroutine BlendToMatrix(Matrix4x4 targetMatrix, float duration)
    {
        StopAllCoroutines();
        return StartCoroutine(LerpFromTo(
            cam.projectionMatrix, targetMatrix, duration));
    }


    public void TogglePerspective(float duration)
    {
        orthoOn = !orthoOn;
        if (orthoOn)
        {
            if (testMode)
                UpdateOrtho(); // update ortho matrix based on public vars 
            BlendToMatrix(ortho, duration);
        }

        else
        {
            if (testMode)
                UpdatePerspective();
            BlendToMatrix(perspective, duration);
        }
    }
}