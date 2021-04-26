using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GroupIcon : MonoBehaviour
{
    [SerializeField]
    private Text m_Text = null;
    [SerializeField]
    private Image m_Image = null;
    [SerializeField]
    private GroupController m_GroupController = null;
    [SerializeField]
    private Group m_Group = null;

    public Group group
    {
        get => m_Group;
    }

    public GroupController GroupController
    {
        set
        {
            m_GroupController = value;
        }
        get
        {
            return m_GroupController;
        }
    }

    private void Awake()
    {
        m_Text = GetComponentInChildren<Text>();
        m_Image = GetComponentInChildren<Image>();
    }

    void SetTextValue(int value)
    {
        string text = value.ToString();

        m_Text.text = text + "%";
    }

    public void AssignGroup(Group group)
    {
        m_Group = group;
        SetTextValue(group.CurrentInfluence);
    }

    public void UpdateText(int value)
    {
        SetTextValue(value);
    }
}
