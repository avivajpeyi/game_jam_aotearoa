using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChanger : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Texture[] textures;
    [SerializeField] private Texture defaultTexture;
    [SerializeField] private float switchTime = 1f;

    private int currentTextureIndex = 0;
    private Coroutine switchCoroutine;
    private bool isObjectActive = true;

    private void Start()
    {
        if (material == null)
        {
            // If the material reference is not set, try to get it from the same game object
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                material = renderer.material;
            }
        }

        // Store the default texture
        defaultTexture = material.mainTexture;

        // Start switching textures
        StartSwitching();
    }

    private void OnEnable()
    {
        // Set the object as active
        isObjectActive = true;
        StartSwitching();
    }

    private void OnDisable()
    {
        // Set the object as inactive and reset the texture to default
        isObjectActive = false;
        ResetTexture();
    }

    private void StartSwitching()
    {
        if (switchCoroutine != null)
        {
            // If the switchCoroutine is already running, stop it
            StopCoroutine(switchCoroutine);
        }

        // Start the switch coroutine only if the object is active
        if (isObjectActive)
        {
            switchCoroutine = StartCoroutine(SwitchTexturesCoroutine());
        }
    }

    private IEnumerator SwitchTexturesCoroutine()
    {
        while (true)
        {
            // Switch to the next texture
            material.mainTexture = textures[currentTextureIndex];

            // Increment the texture index
            currentTextureIndex = (currentTextureIndex + 1) % textures.Length;

            // Wait for the specified switch time
            yield return new WaitForSeconds(switchTime);
        }
    }

    public void SetTextures(Texture[] newTextures)
    {
        // Update the array of textures and restart switching
        textures = newTextures;
        currentTextureIndex = 0;
        StartSwitching();
    }

    public void SetSwitchTime(float newSwitchTime)
    {
        // Update the switch time
        switchTime = newSwitchTime;
        StartSwitching();
    }

    public void ResetTexture()
    {
        // Reset the texture to the default
        material.mainTexture = defaultTexture;
    }
}
