using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RandomPresetOnSpawn : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PresetsScriptableObject presetsScriptableObject;

    // Start is called before the first frame update
    void Start()
    {
        Player randomPreset = presetsScriptableObject.PresetRobos[Random.Range(0, presetsScriptableObject.PresetRobos.Count - 1)];
        Instantiate(randomPreset, Vector3.zero, Quaternion.identity, transform).Input = playerInput;
    }
}
