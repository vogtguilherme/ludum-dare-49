using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class Decision
{
    [SerializeField]
    private string m_DecisionText;
    [SerializeField]
    private Consequence[] m_Consequences;

    public string DecisionText { get => m_DecisionText; }
    public Consequence[] Consequences { get => m_Consequences;}

    public Decision(string decisionText, Consequence[] consequences)
    {
        m_DecisionText = decisionText;
        m_Consequences = consequences;
    }
}

[Serializable]
public class Consequence
{
    [SerializeField]
    Group affectedGroup;
    [SerializeField]
    int influenceAlteration;    

    public Group Group
    {
        get => affectedGroup;
    }

    public int Influence
    {
        get => influenceAlteration;
    }

    public Consequence(Group affectedGroup, int influenceAlteration)
    {
        this.affectedGroup = affectedGroup;
        this.influenceAlteration = influenceAlteration;
    }
}