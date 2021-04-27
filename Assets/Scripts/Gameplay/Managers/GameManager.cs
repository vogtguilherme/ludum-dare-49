using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager s_Instance = null;

    public static GameManager Instance
    {
        get => s_Instance;
    }

    public event Action OnTurnEnd;     //Aqui é o melhor lugar pra esse evento?
    public event Action<Situation> OnDecisionMade;

    [SerializeField]
    private GameObject situationController = null;
    [SerializeField]
    private GameObject groupController = null;

    public GroupController m_GroupController { get; private set; }
    public SituationController m_SituationController { get; private set; }
    public SituationLibrary m_SituationLibrary { get; private set; }

    private bool decisionMade = false;
    private bool gameOver = false;
    private bool criticSituation = false;

    private int iterations = 0;
    private int maxIterations;

    private void Awake()
    {
        SetupSingleton();

        GetScriptReferences();
    }

    private void Start()
    {
        gameOver = false;

        m_SituationLibrary.GenerateSituations();
        m_GroupController.CreateGroups();

        StartCoroutine(GameLoop());
    }

    #region Game Logic

    IEnumerator GameLoop()
    {
        Group n_Group = null;

        maxIterations = UnityEngine.Random.Range(3, 5);

        while (gameOver == false)
        {
            Situation situation;

            if(iterations == maxIterations)
            {
                situation = m_SituationLibrary.GetRareSituation();
                iterations = 0;
                maxIterations = UnityEngine.Random.Range(3, 5);
            }
            else
            {
                situation = m_SituationLibrary.GetCommonSituation();
            }            

            if(situation == null)
            {
                gameOver = true;
            }
            else
            {
                m_SituationController.SetCurrentSituation(situation);

                UIManager.Instance.SetCharacterSprite(situation.m_CharacterSprite);
                UIManager.Instance.SetSituationEnvironment(situation.m_SituationBackground);

                Debug.Log("Nova situação!");

                UIManager.Instance.FadeInPanels();
                yield return new WaitForSeconds(2f);

                while (decisionMade == false)
                {
                    Debug.Log("Esperando decisão...");

                    yield return null;
                }

                Debug.Log("Decisão tomada!");

                if (OnDecisionMade != null)
                {
                    OnDecisionMade.Invoke(m_SituationController.CurrentSituation);
                }

                decisionMade = false;

                UIManager.Instance.FadeOutPanels();

                yield return new WaitForSeconds(.5f);

                var n_Situation = m_SituationController.CurrentSituation;

                UIManager.Instance.FadeOutCharacter();

                n_Group = GetGroupStats();

                if (n_Group != null)
                {

                }

                situation = null;
            }

            iterations++;

            yield return new WaitForSeconds(2f);           
        }

        Debug.Log("GameOver");

        SceneManager.LoadScene("GameOver");
    }
    
    #endregion

    public Group GetGroupStats()
    {
        Group group = null;
        
        for (int i = 0; i < m_GroupController.Groups.Length; i++)
        {
            if(m_GroupController.Groups[i].LowInfluence)
            {
                criticSituation = true;
                group = m_GroupController.Groups[i];
            }
        }

        return group;
    }

    public void ConfirmDecision()
    {
        decisionMade = true;

        if(OnTurnEnd != null)
        {
            OnTurnEnd();
        }
    }

    void SetupSingleton()
    {
        if(s_Instance == null && s_Instance != this)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void GetScriptReferences()
    {
        if (situationController != null)
        {
            m_SituationController = situationController.GetComponent<SituationController>();
            m_SituationLibrary = situationController.GetComponent<SituationLibrary>();
        }
        if(groupController != null)
        {
            m_GroupController = groupController.GetComponent<GroupController>();
        }
    }
}
