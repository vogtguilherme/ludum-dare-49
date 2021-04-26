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
    public List<Situation> m_RareSituations { get; private set; }
    public List<Situation> m_ExceptionalSituations { get; private set; }

    private void Awake()
    {
        m_CommonSituations = new List<Situation>();
        m_RareSituations = new List<Situation>();
        m_ExceptionalSituations = new List<Situation>();
    }

    private void Start()
    {
        GameManager.Instance.OnDecisionMade += RemoveCommonSituation;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnDecisionMade -= RemoveCommonSituation;
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

    void RemoveCommonSituation(Situation situation)
    {
        m_CommonSituations.Remove(situation);
    }

    int GetIndexInsideList(List<Situation> situationList)
    {
        int index;

        int max = situationList.Count;
        index = Random.Range(0, max);
        Debug.Log("Index: " + index);
        return index;
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
                    break;
                case SituationType.Exceptional:
                    m_ExceptionalSituations.Add(m_Situations[i]);
                    break;
            }
        }
    }
}
