using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CameraPerspectiveChanger))]
public class TestPerspectiveSwitcher : MonoBehaviour
{
   
    private CameraPerspectiveChanger blender;


    public bool testMode = false;

    void Start()
    {
        blender = (CameraPerspectiveChanger)GetComponent(typeof(CameraPerspectiveChanger));
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            blender.TogglePerspective(0.5f);
        }
    }
}