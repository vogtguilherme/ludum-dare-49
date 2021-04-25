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
        ClampInfluenceValue(m_CurrentInfluence + value);      
    }

    public void RemoveInfluence(int value)
    {
        ClampInfluenceValue(m_CurrentInfluence - value);
    }

    private int ClampInfluenceValue(int value)
    {
        int clampedValue = Mathf.Clamp(value, 0, 100);

        Debug.Log(m_GroupName + " current influence: " + clampedValue);
        m_CurrentInfluence = clampedValue;

        return clampedValue;
    }
}
