using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Decisions = null;
    [SerializeField]
    private DecisionButton[] m_DecisionButton = null;
        
    public DecisionButton[] decisionButton { get => m_DecisionButton; }

    private void Awake()
    {
        GetComponents();
    }

    void GetComponents()
    {
        m_Decisions = new GameObject[transform.childCount];
        m_DecisionButton = new DecisionButton[transform.childCount];

        for (int i = 0; i < m_Decisions.Length; i++)
        {
            m_Decisions[i] = transform.GetChild(i).gameObject;
            m_DecisionButton[i] = transform.GetChild(i).GetComponent<DecisionButton>();
        }
    }
}
