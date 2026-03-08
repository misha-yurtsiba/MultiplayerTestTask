using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private CameraSettings _cameraSettings;
    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void LateUpdate()
    {
        if (_target == null) return;

        Vector3 targetPosition = _target.position + _cameraSettings.Offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            _cameraSettings.SmoothSpeed * Time.deltaTime);

        transform.LookAt(_target);
    }
}