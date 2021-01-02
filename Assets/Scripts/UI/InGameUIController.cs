using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUIController : MonoBehaviour
{
    [SerializeField]
    CanvasGroup panel;

    [SerializeField]
    Button btnReload;

    [SerializeField]
    Button btnExit;

    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        btnReload.onClick.AddListener(() => {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(buildIndex);
        });

        btnExit.onClick.AddListener(() => {
            Application.Quit();
        });

        HideAll();
    }

    void HideAll()
    {
        panel.alpha = 0.0f;
        panel.interactable = false;
    }

    public void Show()
    {
        panel.alpha = 1.0f;
        panel.interactable = true;
    }
}

