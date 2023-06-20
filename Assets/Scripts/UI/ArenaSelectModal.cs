using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaSelectModal : BaseModal
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button doneButton;
    [SerializeField] private Image arenaPreview;
    [SerializeField] private RoboSelectModal roboSelectModal;

    private void Start()
    {
        leftButton.onClick.AddListener(OnLeftPressed);
        rightButton.onClick.AddListener(OnRightPressed);
        rightButton.onClick.AddListener(OnDonePressed);
    }

    private void OnLeftPressed()
    {

    }
    private void OnRightPressed()
    {

    }
    private void OnDonePressed()
    {

    }
}
