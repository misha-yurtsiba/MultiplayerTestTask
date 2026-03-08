using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettings", menuName = "Configs/CameraSettings")]

public class CameraSettings : ScriptableObject
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed;

    public Vector3 Offset => _offset;
    public float SmoothSpeed => _smoothSpeed;
}