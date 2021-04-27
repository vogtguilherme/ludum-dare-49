using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private Button m_Button = null;
    [SerializeField]
    private string sceneToLoad;

    private void Awake()
    {
        m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(HandleButtonPress);
    }

    private void OnDisable()
    {
        m_Button.onClick.RemoveListener(HandleButtonPress);
    }

    void HandleButtonPress()
    {
        LoadScene(sceneToLoad);
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
