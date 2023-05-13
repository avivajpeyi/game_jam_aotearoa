using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOn2DMode : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        ScriptableEvents.eventActivate2D += Disable;
        ScriptableEvents.eventActivate3D += Enable;
    }
    
    public void OnDestroy()
    {
        ScriptableEvents.eventActivate2D -= Disable;
        ScriptableEvents.eventActivate3D -= Enable;
    }

    // Update is called once per frame
    void Disable()
    {
        // disable all children
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    
    void Enable()
    {
        // enable all children
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
