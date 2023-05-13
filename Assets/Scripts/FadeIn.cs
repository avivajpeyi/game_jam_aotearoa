using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public void Start()
    {
        textDisplay = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeInTxt());
    }
 
    private IEnumerator FadeInTxt()
    {
        float duration = 4f; //Fade out over 2 seconds.
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0, 1f, currentTime / duration);
            textDisplay.color = new Color(textDisplay.color.r, textDisplay.color.g, textDisplay.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}
