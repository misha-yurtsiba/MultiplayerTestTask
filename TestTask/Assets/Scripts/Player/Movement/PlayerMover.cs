using System;
using Fusion;
using UnityEngine;

public class PlayerMover
{
    private readonly NetworkCharacterController _controller;
    private readonly Transform _transform;
    private readonly PlayerConfig _config;

    public PlayerMover(
        NetworkCharacterController controller,
        Transform transform,
        PlayerConfig config)
    {
        _controller = controller;
        _transform = transform;
        _config = config;

        _controller.maxSpeed = config.MovementSpeed;
        _controller.rotationSpeed = config.MovementSpeed;
    }

    public void Move(Vector3 direction, float deltaTime)
    {
        _controller.Move(direction * deltaTime * _config.MovementSpeed);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _transform.rotation = Quaternion.Slerp(
                _transform.rotation,
                targetRotation,
                _config.RotationSpeed * deltaTime);
        }
    }
}