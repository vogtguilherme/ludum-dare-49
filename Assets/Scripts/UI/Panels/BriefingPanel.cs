using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BriefingPanel : MonoBehaviour
{
    [SerializeField]
    private Text m_BriefingText = null;

    private void Awake()
    {
        m_BriefingText = GetComponentInChildren<Text>();
    }

    public void SetBriefingText(string text)
    {
        m_BriefingText.text = text;
    }
}
