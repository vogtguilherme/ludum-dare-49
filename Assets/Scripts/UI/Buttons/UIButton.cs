using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public abstract class UIButton : MonoBehaviour
{
    public event Action OnButtonClick;
    
    protected Button m_Button = null;

    protected virtual void Awake()
    {
        m_Button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        m_Button.onClick.AddListener(HandleButtonClick);
    }

    private void OnDisable()
    {
        m_Button.onClick.RemoveListener(HandleButtonClick);
    }

    protected virtual void HandleButtonClick()
    {
        OnButtonClick?.Invoke();
    }
}
