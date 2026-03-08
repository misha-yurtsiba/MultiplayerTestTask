using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMover", menuName = "Configs/PlayerMover")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _acceleration;
    
    public float MovementSpeed => _movementSpeed;
    public float RotationSpeed => _rotationSpeed;
    public float Acceleration => _acceleration;
}