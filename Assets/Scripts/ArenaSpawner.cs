using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns the player selected arena on arena start.
/// </summary>

public class ArenaSpawner : MonoBehaviour {
  [SerializeField] private ArenasScriptableObject arenas;

  // Start is called before the first frame update
  void Start() {
    Instantiate(arenas.Arenas[PlayerPrefs.GetInt("arena")].gameObject);
  }
}
