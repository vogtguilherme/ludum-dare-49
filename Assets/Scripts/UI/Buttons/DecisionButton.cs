using UnityEngine;
using UnityEngine.UI;

public class DecisionButton : UIButton
{
    private Text m_Text = null;

    private Decision m_Decision = null;

    protected override void Awake()
    {
        base.Awake();

        m_Text = GetComponentInChildren<Text>();
    }

    protected override void HandleButtonClick()
    {
        base.HandleButtonClick();

        GameManager.Instance.ConfirmDecision();
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

    public void SetButtonInteractable(bool interactable)
    {
        m_Button.interactable = interactable;
    }
}
