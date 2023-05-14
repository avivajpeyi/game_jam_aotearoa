using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    // public TextMeshProUGUI textDisplay;
    public Image img;
    public void Start()
    {
        // textDisplay = GetComponent<TextMeshProUGUI>();
        img = GetComponent<Image>();
        StartCoroutine(FadeInTxt());
    }
 
    private IEnumerator FadeInTxt()
    {
        float duration = 4f; //Fade out over 2 seconds.
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0, 1f, currentTime / duration);
            // textDisplay.color = new Color(textDisplay.color.r, textDisplay.color.g, textDisplay.color.b, alpha);


            img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}
