using System;
using Photon.Voice.Unity;
using UnityEngine;

public class VoiceRecorderController : MonoBehaviour
{
    public event Action<bool> OnVoiceDetected;
    
    private Recorder _recorder;

    public void Initialize(Recorder recorder)
    {
        _recorder = recorder;
    }
    
    private void Update()
    {
        if (_recorder == null) return;

        bool speaking = _recorder.VoiceDetector.Detected;
        OnVoiceDetected?.Invoke(speaking);
    }

    public void SetRecording(bool enabled)
    {
        _recorder.RecordingEnabled = enabled;
    }
}