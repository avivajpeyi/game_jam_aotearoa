using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimkinVisible : MonoBehaviour
{
    [SerializeField] bool chimkinIn3D = false;
    [SerializeField] GameObject chimkin2D;
    [SerializeField] GameObject chimkin3D;
    // Start is called before the first frame update
    void Start()
    {
        ScriptableEvents.eventActivate2D += ActivateChimkin2D;
        ScriptableEvents.eventActivate3D += ActivateChimkin3D;
    }

    public void OnDestroy()
    {
        ScriptableEvents.eventActivate2D -= ActivateChimkin2D;
        ScriptableEvents.eventActivate3D -= ActivateChimkin3D;
    }

    void ActivateChimkin2D()
    {
        chimkinIn3D = false;
        chimkin3D.SetActive(false);
        chimkin2D.SetActive(true);
    }

    void ActivateChimkin3D()
    {
        chimkinIn3D = true;
        chimkin3D.SetActive(true);
        chimkin2D.SetActive(false);
    }
}
