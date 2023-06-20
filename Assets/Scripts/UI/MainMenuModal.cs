using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuModal : BaseModal
{

    [SerializeField] private Button playButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private BaseModal controlsModal;
    [SerializeField] private BaseModal creditsModal;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        playButton.onClick.AddListener(OnPlayPressed);
        controlsButton.onClick.AddListener(OnControlsPressed);
        creditsButton.onClick.AddListener(OnCreditsPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
        Open();
    }

    private void OnPlayPressed()
    {
        CloseAll();
    }

    private void OnControlsPressed()
    {
        OpenSubModal(controlsModal);
    }

    private void OnCreditsPressed()
    {
        OpenSubModal(creditsModal);
    }

    private void OnQuitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif

    }
}
