using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BriefingPanel : UIPanel
{
    [SerializeField]
    private Text m_BriefingText = null;

    protected override void Awake()
    {
        base.Awake();

        m_BriefingText = GetComponentInChildren<Text>();
    }

    public void SetBriefingText(string text)
    {
        m_BriefingText.text = text;
    }
}
