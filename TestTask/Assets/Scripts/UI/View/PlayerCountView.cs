using TMPro;
using UnityEngine;

public class PlayerCountView : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerCountText;

    public void SetPlayerCountText(int playerCount)
    {
        _playerCountText.text = $"Players count {playerCount.ToString()}";
    }
}