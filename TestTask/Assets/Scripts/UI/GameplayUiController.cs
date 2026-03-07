using UnityEngine;

public class GameplayUiController : MonoBehaviour
{
    [SerializeField] private CreateLobbyView _createLobbyView;

    public void Initialize()
    {
        _createLobbyView.Initialize();

        SetLobbyViewActive(true);
    }
    
    public void SetLobbyViewActive(bool isActive) => _createLobbyView.gameObject.SetActive(isActive);
}
