using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndModal : MonoBehaviour {
  [field: SerializeField] private Button playAgainButton;
  [field: SerializeField] private Button mainMenuButton;

  // Start is called before the first frame update
  void Start() {
    playAgainButton.onClick.AddListener(OnPlayAgainPressed);
    mainMenuButton.onClick.AddListener(OnMainMenuPressed);
  }

  private void OnPlayAgainPressed() {
   //SceneManager.LoadScene("Level1");
  }

  private void OnMainMenuPressed() {
    SceneManager.LoadScene("MainMenu");
  }
}
