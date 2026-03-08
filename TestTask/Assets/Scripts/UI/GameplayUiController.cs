using UnityEngine;

public class GameplayUiController : MonoBehaviour
{
    [SerializeField] private CreateLobbyView _createLobbyView;
    [SerializeField] private PlayerCountView _playerCountView;


    public void Initialize()
    {
        _createLobbyView.Initialize();

        SetLobbyViewActive(true);
        SetPlayerCountViewActive(false);
    }
    
    public void SetLobbyViewActive(bool isActive) => _createLobbyView.gameObject.SetActive(isActive);
    public void SetPlayerCountViewActive(bool isActive) => _playerCountView.gameObject.SetActive(isActive);
}
