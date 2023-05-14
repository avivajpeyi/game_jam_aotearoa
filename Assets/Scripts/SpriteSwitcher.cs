using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float switchTime = 1f;

    private int currentSpriteIndex = 0;
    private Coroutine switchCoroutine;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            // If the spriteRenderer reference is not set, try to get it from the same game object
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Start switching sprites
        StartSwitching();
    }

    private void StartSwitching()
    {
        if (switchCoroutine != null)
        {
            // If the switchCoroutine is already running, stop it
            StopCoroutine(switchCoroutine);
        }

        // Start the switch coroutine
        switchCoroutine = StartCoroutine(SwitchSpritesCoroutine());
    }

    private IEnumerator SwitchSpritesCoroutine()
    {
        while (true)
        {
            // Switch to the next sprite
            spriteRenderer.sprite = sprites[currentSpriteIndex];

            // Increment the sprite index
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;

            // Wait for the specified switch time
            yield return new WaitForSeconds(switchTime);
        }
    }

    public void SetSprites(Sprite[] newSprites)
    {
        // Update the list of sprites and restart switching
        sprites = newSprites;
        currentSpriteIndex = 0;
        StartSwitching();
    }

    public void SetSwitchTime(float newSwitchTime)
    {
        // Update the switch time
        switchTime = newSwitchTime;
        StartSwitching();
    }
}