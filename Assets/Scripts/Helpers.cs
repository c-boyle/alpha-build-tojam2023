using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Offers an assortment of miscellaneous helper functions.
/// </summary>

public static class Helpers {
  public static void ResetScene() {
    var activeScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(activeScene.name);
  }
}