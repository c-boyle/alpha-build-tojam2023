using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Presets", menuName = "Presets")]
public class PresetsScriptableObject : ScriptableObject
{
    [field: SerializeField] public List<Player> PresetRobos { get; private set; } = new();
    [field: SerializeField] public List<Player> RoboBodies { get; private set; } = new();
    [field: SerializeField] public List<Transform> RoboMods { get; private set; } = new();

    private readonly Dictionary<int, Player> playerIdToChosenRobo = new();

    public void SetChosenRobo(int playeId, Player chosenRobo)
    {
        playerIdToChosenRobo[playeId] = chosenRobo;
    }

    private void Awake()
    {
        if (PlayerInputManager.instance != null)
        {
            PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
            PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
        }
    }

    private void OnPlayerJoined(PlayerInput player)
    {
        playerIdToChosenRobo[player.playerIndex] = PresetRobos[0];
    }

    private void OnPlayerLeft(PlayerInput player)
    {
        playerIdToChosenRobo.Remove(player.playerIndex);
    }
}
