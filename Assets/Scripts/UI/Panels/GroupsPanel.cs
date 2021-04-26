using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GroupsPanel : UIPanel
{
    [SerializeField]
    private GameObject[] m_GroupPanel = null;
    [SerializeField]
    private GroupIcon[] m_GroupIcons = null;

    public GroupIcon[] Icons
    {
        get { return m_GroupIcons; }
    }

    protected override void Awake()
    {
        base.Awake();
        
        GetPanelsGameObject();
    }

    void GetPanelsGameObject()
    {
        m_GroupPanel = new GameObject[transform.childCount];
        m_GroupIcons = new GroupIcon[transform.childCount];

        for (int i = 0; i < m_GroupPanel.Length; i++)
        {
            m_GroupPanel[i] = transform.GetChild(i).gameObject;
            m_GroupIcons[i] = transform.GetChild(i).GetComponent<GroupIcon>();
        }
    }

    public void SetGroups(Group[] groups, GroupController controller)
    {
        for (int i = 0; i < groups.Length; i++)
        {
            m_GroupIcons[i].GroupController = controller;
            m_GroupIcons[i].AssignGroup(groups[i]);
        }
    }

    public GroupIcon GetGroupWithName(string groupName)
    {
        GroupIcon n_Group = null;

        for (int i = 0; i < m_GroupIcons.Length; i++)
        {
            if(m_GroupIcons[i].group.GroupName == groupName)
            {
                n_Group = m_GroupIcons[i];
            }
        }

        return n_Group;
    }
}