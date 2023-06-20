using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MyBox;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class UIEventListener : Singleton<UIEventListener>
{
    [SerializeField] private PauseMenuModal pausedGameModal;
    [SerializeField] private Image fadeBackground;

    private static float timeScaleBeforePause;

    private const string GAME_CONTROLS = "GameControls";
    private const string UI = "UI";

    public bool GameIsPaused { get; private set; }

    private IEnumerator FadeToGameEnd()
    {
        float fadeSeconds = 1f;
        float fadeStep = 1f / fadeSeconds;
        float tickTime = 0.1f;
        var waitTime = new WaitForSecondsRealtime(tickTime);
        while (fadeSeconds > 0)
        {
            yield return waitTime;
            var tempColor = fadeBackground.color;
            tempColor.a += fadeStep * tickTime;
            fadeBackground.color = tempColor;
            fadeSeconds -= tickTime;
        }
        SceneManager.LoadScene("GameEndMenu");
    }

    public void OnPausePressed()
    {
        PauseGame();
        EnableUIControls();
        //controlsPromptPanel.Hide();
        pausedGameModal.Open(() => { UnpauseGame(); DisableUIControls(); });
    }

    public void PauseGame()
    {
        timeScaleBeforePause = Time.timeScale;
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = timeScaleBeforePause;
        GameIsPaused = false;
        //controlsPromptPanel.Show();
    }

    public void EnableUIControls()
    {
        foreach (var player in PlayerInput.all)
        {
            player.actions.FindActionMap(GAME_CONTROLS).Disable();
            player.actions.FindActionMap(UI).Enable();
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DisableUIControls()
    {
        foreach (var player in PlayerInput.all)
        {
            player.actions.FindActionMap(UI).Disable();
            player.actions.FindActionMap(GAME_CONTROLS).Enable();
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void InvokeActions(UnityEvent actions)
    {
        actions.Invoke();
    }
}
