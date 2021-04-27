using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Group
{
    [SerializeField]
    private string m_GroupName;
    private int m_CurrentInfluence;

    public Action OnGropCrisis;
    public Action OnGropCriticSituation;

    public bool lowInfluence = false;

    public string GroupName
    {
        get { return m_GroupName; }
    }

    public int CurrentInfluence
    {
        get { return m_CurrentInfluence; }
    }

    public Group(string groupName)
    {
        m_CurrentInfluence = 70;
        m_GroupName = groupName;
    }

    public void IncreaseInfluence(int value)
    {
        int newValue = m_CurrentInfluence + value;

        if(newValue > 100)
        {
            m_CurrentInfluence = 100;
        }
        else if (newValue < 15)
        {
            m_CurrentInfluence = 10;

            if (OnGropCriticSituation != null)
            {
                OnGropCriticSituation();
            }

            lowInfluence = true;

        }
        else if (newValue < 0 || newValue < 15 && lowInfluence == true)
        {
            m_CurrentInfluence = 10;

            if (OnGropCrisis != null)
            {
                OnGropCrisis();
            }
        }
        else
        {
            m_CurrentInfluence = newValue;
        }

        Debug.Log(m_GroupName + " current influence: " + m_CurrentInfluence);
    }
}
