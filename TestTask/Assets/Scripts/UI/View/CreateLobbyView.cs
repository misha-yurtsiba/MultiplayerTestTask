using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateLobbyView : MonoBehaviour, ILobbyView
{
    [SerializeField] private TMP_InputField _lobbyNameInputField;
    
    [SerializeField] private Button _createLobbyButton;
    [SerializeField] private Button _exitGameButton;
    
    public event Action<CreateLobbyData> OnCreateLobbyButtonPressed;

    public void Initialize()
    {
        _createLobbyButton.onClick.AddListener(CreateLobby);
        _exitGameButton.onClick.AddListener(Application.Quit);
    }

    public void CreateLobby()
    {
        OnCreateLobbyButtonPressed?.Invoke(new CreateLobbyData
        {
            LobbyName = _lobbyNameInputField.text
        });
        
        SetButtonInteractable(false);
    }

    public void SetButtonInteractable(bool isActive)
    {
        _createLobbyButton.interactable = isActive;
    }
}

public class CreateLobbyData
{
    public string LobbyName;
}

public interface ILobbyView
{
    event Action<CreateLobbyData> OnCreateLobbyButtonPressed;
    void SetButtonInteractable(bool isActive);
}