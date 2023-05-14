using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOn3D : MonoBehaviour
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
        gameObject.SetActive(false);
    }

    void Enable()
    {
        gameObject.SetActive(true);
    }
}
