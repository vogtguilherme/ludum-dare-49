using UnityEngine;
using UnityEngine.UI;

public class DecisionButton : UIButton
{
    [SerializeField]
    private Text m_Text = null;

    private Decision m_Decision = null;

    protected override void Awake()
    {
        base.Awake();

        m_Text = GetComponentInChildren<Text>();
    }

    public void AssignDecision(Decision decision)
    {
        m_Decision = decision;
        SetDecisionText(decision.DecisionText);
    }

    public void SetDecisionText(string _text)
    {
        m_Text.text = _text;
    }
}
