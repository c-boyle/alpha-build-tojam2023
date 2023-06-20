using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArenaSelectModal : BaseModal {
  [SerializeField] private Button leftButton;
  [SerializeField] private Button rightButton;
  [SerializeField] private Button doneButton;
  [SerializeField] private Image arenaPreview;
  //[SerializeField] private RoboSelectModal roboSelectModal;
  [SerializeField] private ArenasScriptableObject arenas;

  private int arenaIndex = 0;

  private void Start() {
    leftButton.onClick.AddListener(OnLeftPressed);
    rightButton.onClick.AddListener(OnRightPressed);
    doneButton.onClick.AddListener(OnDonePressed);
    arenaPreview.sprite = arenas.Arenas[arenaIndex].sprite;
  }

  private void OnLeftPressed() {
    arenaIndex--;
    if (arenaIndex < 0) {
      arenaIndex = arenas.Arenas.Count - 1;
    }
    arenaPreview.sprite = arenas.Arenas[arenaIndex].sprite;
  }

  private void OnRightPressed() {
    arenaIndex = (arenaIndex + 1) % arenas.Arenas.Count;
    arenaPreview.sprite = arenas.Arenas[arenaIndex].sprite;
  }

  private void OnDonePressed() {
    PlayerPrefs.SetInt("arena", arenaIndex);
    SceneManager.LoadScene("Arena");
  }
}
