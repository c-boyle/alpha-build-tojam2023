using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenuModal : BaseModal {
  [SerializeField] private Button continueButton;
  [SerializeField] private Button controlsButton;
  [SerializeField] private Button mainMenuButton;
  [SerializeField] private BaseModal controlsModal;

  private void Start() {
    continueButton.onClick.AddListener(OnContinuePressed);
    controlsButton.onClick.AddListener(OnControlsPressed);
    mainMenuButton.onClick.AddListener(OnMainMenuPressed);
  }

  private void OnContinuePressed() {
    CloseAll();
  }

  private void OnControlsPressed() {
    OpenSubModal(controlsModal);
  }

  private void OnMainMenuPressed() {
    CloseAll();
    SceneManager.LoadScene("MainMenu");
  }
}
