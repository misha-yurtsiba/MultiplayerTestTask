using UnityEngine;
using UnityEngine.UI;

public class SpeakingIndicatorView : MonoBehaviour
{
    [SerializeField] private Image _indicatorImage;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _indicatorImage.gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        if (_camera != null)
        {
            _indicatorImage.transform.LookAt(_camera.transform);
        }
    }

    public void SetVisible(bool visible)
    {
        _indicatorImage.gameObject.SetActive(visible);
    }
}