using Fusion;
using Photon.Voice.Fusion;
using Photon.Voice.Unity;
using UnityEngine;

[RequireComponent(typeof(PushToTalkInput), typeof(VoiceRecorderController))]
public class VoicePlayerController : NetworkBehaviour
{
    [SerializeField] private Recorder _recorder;
    
    private PushToTalkInput _pushToTalkInput;
    private VoiceRecorderController _voiceRecorderController;
    private NetworkVoiceSync _networkVoiceSync;

    private void Start()
    {
        Player.OnLocalPlayerSpawned += PlayerSpawned;
        
        _pushToTalkInput = GetComponent<PushToTalkInput>();
        _voiceRecorderController = GetComponent<VoiceRecorderController>();
        
        _voiceRecorderController.Initialize(_recorder);
    }

    public override void Spawned()
    {
        Runner.GetComponent<FusionVoiceClient>().PrimaryRecorder = _recorder;
        _pushToTalkInput.OnPushToTalkChanged += _voiceRecorderController.SetRecording;
    }

    private void PlayerSpawned(Player player)
    {
        _networkVoiceSync = player.GetComponent<NetworkVoiceSync>();
        
        _voiceRecorderController.OnVoiceDetected += _networkVoiceSync.SetSpeaking;
    }
    
    private void OnDestroy()
    {
        _pushToTalkInput.OnPushToTalkChanged -= _voiceRecorderController.SetRecording;
        _voiceRecorderController.OnVoiceDetected -= _networkVoiceSync.SetSpeaking;
        
        Player.OnLocalPlayerSpawned -= PlayerSpawned;
    }

}