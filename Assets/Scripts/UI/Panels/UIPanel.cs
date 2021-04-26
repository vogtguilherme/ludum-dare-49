using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    protected CanvasGroup m_CanvasGroup = null;
    [Header("UI Animation")]
    [SerializeField]
    private float m_FadeSpeed = 0.2f;
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

    IEnumerator StartFadeOut()
    {
        Debug.Log("StartFadeOut()");
        m_CanvasGroup.alpha = 1f;

        float fadeValue = 1;

        while (fadeValue > 0)
        {
            fadeValue = Mathf.Lerp(fadeValue, 0, Time.deltaTime * m_FadeSpeed);

            m_CanvasGroup.alpha = fadeValue;

            yield return null;
        }

        Debug.Log("Fade Completed");
    }
}
