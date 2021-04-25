using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class SituationController : MonoBehaviour
{
    public event Action OnNewSituation;
    
    private Situation m_CurrentSituation = null;

    [SerializeField]
    private GameObject m_DecisionPanelObj = null;
    [SerializeField]
    private GameObject m_BriefingPanelObj = null;

    private DecisionPanel m_DecisionPanel = null;
    private BriefingPanel m_BriefingPanel = null;

    public Situation CurrentSituation { get => m_CurrentSituation; }

    private void Awake()
    {
        if(m_DecisionPanelObj != null)
        {
            m_DecisionPanel = m_DecisionPanelObj.GetComponent<DecisionPanel>();
        }

        if(m_BriefingPanelObj != null)
        {
            m_BriefingPanel = m_BriefingPanelObj.GetComponent<BriefingPanel>();
        }
    }

    public void SetCurrentSituation(Situation situation)
    {
        m_CurrentSituation = situation;

        if(OnNewSituation != null)
        {
            OnNewSituation.Invoke();
        }

        SetSituationDataOnInterface();

        m_DecisionPanel.SetButtonInteraction(true);
    }

    void SetSituationDataOnInterface()
    {
        if (m_CurrentSituation == null) return;
        
        for (int i = 0; i < m_DecisionPanel.decisionButton.Length; i++)
        {
            var decision = m_CurrentSituation.m_Decisions[i];

            if (decision != null)
                m_DecisionPanel.decisionButton[i].AssignDecision(decision);
            else
                Debug.LogError("Sem referencia de decisão");
        }

        var briefingText = m_CurrentSituation.m_Briefing;
        m_BriefingPanel.SetBriefingText(briefingText);
    }
}