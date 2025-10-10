using System;
using TMPro;
using UnityEngine;

public class PlayModeController : MonoBehaviour
{
    [SerializeField] private ControlButtons _buttons;
    [SerializeField] private GameObject _interactPanel;
    [SerializeField] private TMP_Text _interactButton;
    [SerializeField] private TMP_Text _interactDecription;

    public void MainMenuClick()
    {
        LoadingManager.Instance.LoadScene("MainMenu");
    }

    private void OnEnable()
    {
        Interactable.InteractEntered += OnInteractEnter;
        Interactable.InteractExited += OnInteractExit;
    }

    private void OnDisable()
    {
        Interactable.InteractEntered -= OnInteractEnter;
        Interactable.InteractExited -= OnInteractExit;
    }

    private void OnInteractEnter(string action)
    {
        _interactPanel.SetActive(true);
        _interactDecription.text = action;
        _interactButton.text = _buttons.Interact.ToString();
    }

    private void OnInteractExit()
    {
        _interactPanel.SetActive(false);
    }
}
