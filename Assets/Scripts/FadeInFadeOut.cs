using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    public static FadeInFadeOut instance;

    public Image image;
    public float fadeSpeed = 1.0f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    public void FadeIn()
    {
        StartCoroutine(FadeAlpha());
    }

    public void DecreaseAlpha()
    {
        StartCoroutine(FadeAlpha());
    }

    private IEnumerator FadeAlpha()
    {
        Color color = image.color;
        //float startAlpha = color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * fadeSpeed)
        {
            float newAlpha = Mathf.Lerp(0, 1, t);
            image.color = new Color(color.r, color.g, color.b, newAlpha);
            yield return null;
        }

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * fadeSpeed)
        {
            float newAlpha = Mathf.Lerp(1, 0, t);
            image.color = new Color(color.r, color.g, color.b, newAlpha);
            yield return null;
        }
        //image.color = new Color(color.r, color.g, color.b, targetAlpha);
    }
}