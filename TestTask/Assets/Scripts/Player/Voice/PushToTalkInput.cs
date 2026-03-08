using System;
using UnityEngine;

public class PushToTalkInput : MonoBehaviour
{
    public event Action<bool> OnPushToTalkChanged;

    [SerializeField] private KeyCode _key = KeyCode.V;

    private bool _lastState = false;

    private void Update()
    {
        bool pressed = Input.GetKey(_key);

        if (pressed == _lastState) return;

        _lastState = pressed;
        OnPushToTalkChanged?.Invoke(pressed);
    }
}