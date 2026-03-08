using System;
using Fusion;
using UnityEngine;

public class NetworkVoiceSync : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(OnSpeakingChanged))]
    public bool IsSpeaking { get; set; }
    
    private SpeakingIndicatorView _speakingIndicator;

    public override void Spawned()
    {
        _speakingIndicator = GetComponent<SpeakingIndicatorView>();
    }

    private void OnSpeakingChanged()
    {
        _speakingIndicator.SetVisible(IsSpeaking);
    }

    public void SetSpeaking(bool value)
    {
        if (!HasInputAuthority) return;

        RPC_SetSpeaking(value);
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority, HostMode = RpcHostMode.SourceIsHostPlayer)]
    private void RPC_SetSpeaking(bool value)
    {
        IsSpeaking = value;
    }
}


