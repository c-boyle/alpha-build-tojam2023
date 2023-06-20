using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A collection of robo presets and robo parts that can be used to make a robo.
/// </summary>

[CreateAssetMenu(fileName = "Presets", menuName = "Presets")]
public class PresetsScriptableObject : ScriptableObject {
  [field: SerializeField] public List<Player> PresetRobos { get; private set; } = new();
  [field: SerializeField] public List<Player> RoboBodies { get; private set; } = new();
  [field: SerializeField] public List<Transform> RoboMods { get; private set; } = new();
}
