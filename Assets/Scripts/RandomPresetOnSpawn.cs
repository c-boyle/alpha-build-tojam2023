using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Assmbles a random preset robo on spawn for a player.
/// </summary>

public class RandomPresetOnSpawn : MonoBehaviour {
  [SerializeField] private PlayerInput playerInput;
  [SerializeField] private PresetsScriptableObject presetsScriptableObject;
  [SerializeField] private bool useCompletelyRandomRobo = false;

  private void Start() {
    Player randomPreset = useCompletelyRandomRobo ? presetsScriptableObject.RoboBodies[Random.Range(0, presetsScriptableObject.RoboBodies.Count - 1)] : presetsScriptableObject.PresetRobos[Random.Range(0, presetsScriptableObject.PresetRobos.Count - 1)];
    Player spawnedPlayer = Instantiate(randomPreset, transform, true);
    if (useCompletelyRandomRobo) {
      RoboMod spawnedRoboModEast = Instantiate(presetsScriptableObject.RoboMods[Random.Range(0, presetsScriptableObject.RoboMods.Count - 1)], spawnedPlayer.Robo.RoboModEastPos, false).GetComponentInChildren<RoboMod>();
      RoboMod spawnedRoboModWest = Instantiate(presetsScriptableObject.RoboMods[Random.Range(0, presetsScriptableObject.RoboMods.Count - 1)], spawnedPlayer.Robo.RoboModWestPos, false).GetComponentInChildren<RoboMod>();
      RoboMod spawnedRoboModNorth = Instantiate(presetsScriptableObject.RoboMods[Random.Range(0, presetsScriptableObject.RoboMods.Count - 1)], spawnedPlayer.Robo.RoboModNorthPos, false).GetComponentInChildren<RoboMod>();

      spawnedPlayer.Robo.RoboModEast = spawnedRoboModEast;
      spawnedPlayer.Robo.RoboModWest = spawnedRoboModWest;
      spawnedPlayer.Robo.RoboModNorth = spawnedRoboModNorth;

      spawnedRoboModEast.Owner = spawnedPlayer.Robo;
      spawnedRoboModWest.Owner = spawnedPlayer.Robo;
      spawnedRoboModNorth.Owner = spawnedPlayer.Robo;
    }
    spawnedPlayer.Input = playerInput;
  }
}
