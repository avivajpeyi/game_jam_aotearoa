using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableChildrenOnDifferentPerspective : MonoBehaviour
{
    [SerializeField] private bool is3Dobject = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (is3Dobject)
        {
            ScriptableEvents.eventActivate2D += Disable;
            ScriptableEvents.eventActivate3D += Enable;
        }
        else
        {
            ScriptableEvents.eventActivate2D += Enable;
            ScriptableEvents.eventActivate3D += Disable;
        }
    }

    public void OnDestroy()
    {
        if (is3Dobject)
        {
            ScriptableEvents.eventActivate2D -= Disable;
            ScriptableEvents.eventActivate3D -= Enable;
        }
        else
        {
            ScriptableEvents.eventActivate2D -= Enable;
            ScriptableEvents.eventActivate3D -= Disable;
        }
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