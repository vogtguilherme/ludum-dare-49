using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionPanel : UIPanel
{
    [SerializeField]
    private GameObject[] m_Decisions = null;
    [SerializeField]
    private DecisionButton[] m_DecisionButton = null;
        
    public DecisionButton[] decisionButton { get => m_DecisionButton; }

    protected override void Awake()
    {
        base.Awake();
        
        GetComponents();
    }

    private void OnDisable()
    {
        UnassignButtonEvent();
    }

    void GetComponents()
    {
        m_Decisions = new GameObject[transform.childCount];
        m_DecisionButton = new DecisionButton[transform.childCount];

        for (int i = 0; i < m_Decisions.Length; i++)
        {
            m_Decisions[i] = transform.GetChild(i).gameObject;
            m_DecisionButton[i] = transform.GetChild(i).GetComponent<DecisionButton>();
            m_DecisionButton[i].OnButtonClick += HandleDecisionButtonClick;
        }
    }

    void UnassignButtonEvent()
    {
        for (int i = 0; i < m_DecisionButton.Length; i++)
        {
            m_DecisionButton[i].OnButtonClick -= HandleDecisionButtonClick;
        }
    }

    void HandleDecisionButtonClick()
    {
        SetButtonInteraction(false);
    }

    public void SetButtonInteraction(bool value)
    {
        for (int i = 0; i < m_DecisionButton.Length; i++)
        {
            m_DecisionButton[i].SetButtonInteractable(value);
        }
    }
}
