using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituationController : MonoBehaviour
{
    [SerializeField]
    private SituationData situationData = null;
    private Situation m_CurrentSituation = null;
    [SerializeField]
    private GameObject m_DecisionPanelObj = null;

    private DecisionPanel m_DecisionPanel = null;

    public Situation CurrentSituation { get => m_CurrentSituation; }

    private void Awake()
    {
        if(m_DecisionPanelObj != null)
        {
            m_DecisionPanel = m_DecisionPanelObj.GetComponent<DecisionPanel>();
        }
    }

    private void Start()
    {
        m_CurrentSituation = situationData.GetSituation();
        
        for (int i = 0; i < m_DecisionPanel.decisionButton.Length; i++)
        {
            var decision = m_CurrentSituation.m_Decisions[i];

            if (decision != null)
                m_DecisionPanel.decisionButton[i].AssignDecision(decision);
            else
                Debug.LogError("Sem referencia de decisão");

        }
    }
}
