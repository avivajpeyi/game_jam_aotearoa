using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomlyEnable : MonoBehaviour
{
    [SerializeField] float probability = 0.1f;
    MeshRenderer meshRenderer;
    bool destroyed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0f, 1f) > probability)
        {
            destroyed = true;
            Destroy(gameObject);
        }
        else{
            meshRenderer = GetComponent<MeshRenderer>();
            ScriptableEvents.eventActivate2D += Hide;
            ScriptableEvents.eventActivate3D += Show;
        }
    }

    private void OnDestroy()
    {
        if (!destroyed)
        {
            ScriptableEvents.eventActivate2D -= Hide;
            ScriptableEvents.eventActivate3D -= Show;
        }
    }

    void Hide()
    {
        meshRenderer.enabled = false;
    }

    void Show()
    {
        meshRenderer.enabled = true;
    }
    
}
