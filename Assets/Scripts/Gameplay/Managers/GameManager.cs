using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

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
    private bool gameOver;

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
        while(gameOver == false)
        {
            var situation = m_SituationLibrary.GetCommonSituation();

            if (situation == null)
            {
                gameOver = true;                
            }
            else
            {
                m_SituationController.SetCurrentSituation(situation);
                UIManager.Instance.SetCharacterSprite(situation.m_CharacterSprite);

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

                yield return new WaitForSeconds(2f);
            }            

            yield return null;
        }

        Debug.Log("GameOver");
    }
    
    #endregion

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
