using UnityEngine;
using Fusion;
using TMPro;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerStats : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(OnPlayerNameChanged))]
    public NetworkString<_32> PlayerName { get; set; }
    [SerializeField] TextMeshPro playerNameLabel;

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            // Each client sets their own name once
            RPC_SetPlayerName(BasicSpawner.instance._playerName);
        }

        playerNameLabel.text = PlayerName.ToString();
    }
    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    private void RPC_SetPlayerName(string name)
    {
        PlayerName = name;
    }

    private void OnPlayerNameChanged()
    {
        playerNameLabel.text = PlayerName.ToString();
    }
}
