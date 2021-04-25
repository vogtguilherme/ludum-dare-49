using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation
{
    public Group m_Group { get; private set; }
    public SituationType m_SituationType { get; private set; }
    public string m_Briefing { get; private set; }
    public Decision[] m_Decisions { get; private set; }

    public Situation(SituationType situationType, string briefing, int decisionsCount)
    {
        m_SituationType = situationType;
        m_Briefing = briefing;
        m_Decisions = new Decision[decisionsCount];
    }

    public void SetDecisions(Decision[] decisions)
    {
        m_Decisions = decisions;
    }
}

public enum SituationType
{
    Common, Rare, Exceptional
}
