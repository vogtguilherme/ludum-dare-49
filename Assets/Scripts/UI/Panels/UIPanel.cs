using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPanel : MonoBehaviour
{
    protected CanvasGroup m_CanvasGroup = null;
    [Header("UI Animation")]
    [SerializeField]
    private float m_FadeTime = 1f;

    protected virtual void Awake()
    {
        m_CanvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        StartCoroutine(StartFade(0, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(StartFade(1, 0));
    }

    IEnumerator StartFade(float from, float to)
    {
        Debug.Log("StartFade()");
        m_CanvasGroup.alpha = from;
        float elapsedTime = 0f;

        while(elapsedTime < m_FadeTime)
        {
            elapsedTime += Time.deltaTime;
            m_CanvasGroup.alpha = Mathf.Lerp(from, to, elapsedTime / m_FadeTime);
            yield return null;
        }

        Debug.Log("Fade Completed");
    }
}

public static class SpriteFader
{
    public static IEnumerator FadeSprite(Image sprite, Color fromColor, Color toColor, float fadeTime)
    {
        Debug.Log("StartFade()");
        sprite.color = fromColor;
        float elapsedTime = 0f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            sprite.color = Color.Lerp(fromColor, toColor, elapsedTime / fadeTime);
            yield return null;
        }

        Debug.Log("Fade Completed");
    }
}
