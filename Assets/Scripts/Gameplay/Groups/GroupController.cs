using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GroupController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ObjGroupPanel = null;
    private GroupsPanel m_GroupsPanel = null;
    private Group[] groups = null;

    public Group people { get; private set; }
    public Group military { get; private set; }
    public Group parlament { get; private set; }
    public Group privateSector { get; private set; }

    private void Awake()
    {
        GetScriptReference();
    }

    void GetScriptReference()
    {
        if (m_ObjGroupPanel != null)
            m_GroupsPanel = m_ObjGroupPanel.GetComponent<GroupsPanel>();
    }

    //Game Manager
    public void CreateGroups()
    {
        people = new Group("People");
        military = new Group("Military");
        parlament = new Group("Parlament");
        privateSector = new Group("Private Sector");

        groups = new Group[4];

        groups[0] = people;
        groups[1] = military;
        groups[2] = parlament;
        groups[3] = privateSector;

        if(m_GroupsPanel != null)
        {
            m_GroupsPanel.SetGroups(groups, this);
        }
    }
    
    //Botão UI
    public void ApplyDecisionConsequence(Consequence[] consequences)
    {
        for (int i = 0; i < consequences.Length; i++)
        {
            SetGroupConsequence(consequences[i].Group, consequences[i].Influence);
        }
    }

    void SetGroupConsequence(Group group, int value)
    {
        for (int i = 0; i < groups.Length; i++)
        {
            if (groups[i].GroupName == group.GroupName)
            {
                groups[i].IncreaseInfluence(value);
                var icon = m_GroupsPanel.GetGroupWithName(group.GroupName);
                icon.UpdateText(groups[i].CurrentInfluence);
            }
        }   
    }
}
