using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A collection of arenas that can be used in game.
/// </summary>

[CreateAssetMenu(fileName = "Arenas", menuName = "Arenas")]
public class ArenasScriptableObject : ScriptableObject {
  [field: SerializeField] public List<SpriteRenderer> Arenas { get; private set; } = new();
}
