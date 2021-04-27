using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager s_Instance = null;
    
    public static UIManager Instance
    {
        get
        {
            return s_Instance;
        }
    }

    private UIPanel m_DecisionPanel = null;
    private UIPanel m_BriefingPanel = null;
    private UIPanel m_GroupsPanel = null;

    public GameObject decisionPanel = null;
    public GameObject briefingPanel = null;
    public GameObject groupsPanel = null;

    public Image m_CharacterImage = null;
    public Image m_BackgroundImage = null;
    public Image m_ForegroundImage = null;

    [Header("Sprites")]
    public Sprite officeForeground = null;
    public Sprite officeBackground = null;
    public Sprite unForeground = null;
    public Sprite unBackground = null;
    public Sprite liveForeground = null;
    public Sprite liveBackground = null;
    public Sprite hospitalForeground = null;
    public Sprite hospitalBackground = null;
    public Sprite beachBackground = null;

    private void Awake()
    {
        SingletonSetup();
        
        GetScriptReferences();
    }

    private void Start()
    {
        m_CharacterImage.color = new Color(0, 0, 0, 0);
    }

    public void SetSituationEnvironment(SituationBackground background)
    {
        if(background == SituationBackground.Beach)
        {
            m_ForegroundImage.color = new Color(1, 1, 1, 0);
        }
        else
        {
            m_ForegroundImage.color = new Color(1, 1, 1, 1);
        }
        
        switch(background)
        {
            case SituationBackground.Beach:
                SetEnvironment(beachBackground, null);
                break;
            case SituationBackground.UN:
                SetEnvironment(unBackground, unForeground);
                break;
            case SituationBackground.Hospital:
                SetEnvironment(hospitalBackground, hospitalForeground);
                break;
            case SituationBackground.Live:
                SetEnvironment(liveBackground, liveForeground);
                break;
            case SituationBackground.Office:
                SetEnvironment(officeBackground, officeForeground);
                break;
        }
    }
    
    void SetEnvironment(Sprite bg, Sprite fg)
    {
        m_BackgroundImage.sprite = bg;
        m_ForegroundImage.sprite = fg;
    }

    public void SetCharacterSprite(Sprite sprite)
    {
        StartCoroutine(SetNewCharacterAndFadeIn(sprite));
    }

    public void FadeOutCharacter()
    {
        StartCoroutine(CharacterFadeOut());
    }

    IEnumerator SetNewCharacterAndFadeIn(Sprite sprite)
    {
        m_CharacterImage.sprite = sprite;

        yield return SpriteFader.FadeSprite(m_CharacterImage, new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), 1f);
    }

    IEnumerator CharacterFadeOut()
    {
        yield return SpriteFader.FadeSprite(m_CharacterImage, new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), 1f);
    }

    public void FadeOutPanels()
    {
        m_DecisionPanel.FadeOut();
        m_BriefingPanel.FadeOut();
    }

    public void FadeInPanels()
    {
        m_DecisionPanel.FadeIn();
        m_BriefingPanel.FadeIn();
    }

    #region Internal

    void SingletonSetup()
    {
        if (s_Instance == null && s_Instance != this)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void GetScriptReferences()
    {
        if(decisionPanel != null)
        {
            m_DecisionPanel = decisionPanel.GetComponent<DecisionPanel>();
        }
        else
        {
            Debug.LogError("Sem referencia para " + decisionPanel);
        }

        if (briefingPanel != null)
        {
            m_BriefingPanel = briefingPanel.GetComponent<BriefingPanel>();
        }
        else
        {
            Debug.LogError("Sem referencia para " + briefingPanel);
        }

        if (groupsPanel != null)
        {
            m_GroupsPanel = groupsPanel.GetComponent<GroupsPanel>();
        }
        else
        {
            Debug.LogError("Sem referencia para " + groupsPanel);
        }
    }

    #endregion
}