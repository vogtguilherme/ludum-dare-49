using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituationLibrary : MonoBehaviour
{
    [SerializeField]
    private SituationData[] m_SituationData = null;
    [SerializeField]
    private Situation[] m_Situations = null;

    public List<Situation> m_CommonSituations { get; private set; }
    [SerializeField]
    private List<Situation> m_RareSituations = new List<Situation>();// { get; private set; }
    public List<Situation> m_ExceptionalSituations { get; private set; }

    private void Awake()
    {
        m_CommonSituations = new List<Situation>();
        //m_RareSituations = new List<Situation>();
        m_ExceptionalSituations = new List<Situation>();
    }

    private void Start()
    {
        GameManager.Instance.OnDecisionMade += RemoveSituation;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnDecisionMade -= RemoveSituation;
    }

    public Situation GetCommonSituation()
    {
        Situation situation;

        if (m_CommonSituations.Count == 0)
            return null;
        else
        {
            int index = GetIndexInsideList(m_CommonSituations);

            situation = m_CommonSituations[index];
        }        
        
        return situation;
    }

    public Situation GetRareSituation()
    {
        Situation situation = null;

        if (m_RareSituations.Count == 0)
            return null;
        else
        {
            int index = GetIndexInsideList(m_RareSituations);

            situation = m_RareSituations[index];
        }

        return situation;
    }

    public Situation GetCriticSituation(Group group)
    {
        Situation situation;

        situation = GetSituationByGroup(group);        

        return situation;
    }

    void RemoveSituation(Situation situation)
    {
        switch(situation.m_SituationType)
        {
            case SituationType.Common:
                RemoveCommonSituation(situation);
                break;
            case SituationType.Rare:
                RemoveRareSituation(situation);
                break;
        }
    }

    void RemoveCommonSituation(Situation situation)
    {
        m_CommonSituations.Remove(situation);
    }

    void RemoveRareSituation(Situation situation)
    {
        m_RareSituations.Remove(situation);
    }

    int GetIndexInsideList(List<Situation> situationList)
    {
        int index;

        int max = situationList.Count;
        index = Random.Range(0, max);
        Debug.Log("Index: " + index);
        return index;
    }

    Situation GetSituationByGroup(Group group)
    {
        Situation situation = null;
        
        var array = m_ExceptionalSituations.ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            if(array[i].m_Group == group)
            {
                situation = array[i];
            }
        }

        return situation;
    }

    public void GenerateSituations()
    {
        m_Situations = new Situation[m_SituationData.Length];

        for (int i = 0; i < m_SituationData.Length; i++)
        {
            m_Situations[i] = m_SituationData[i].GetSituation();

            switch (m_Situations[i].m_SituationType)
            {
                case SituationType.Common:
                    m_CommonSituations.Add(m_Situations[i]);
                    break;
                case SituationType.Rare:
                    m_RareSituations.Add(m_Situations[i]);
                    Debug.Log("Adicionado");
                    break;
                case SituationType.Exceptional:
                    m_ExceptionalSituations.Add(m_Situations[i]);
                    break;
            }
        }
    }
}
