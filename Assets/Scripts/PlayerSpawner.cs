using Fusion;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined, IPlayerLeft
{
    [SerializeField] private GameObject PlayerPrefab;
    private Dictionary<PlayerRef, NetworkObject> spawnedPlayer = new Dictionary<PlayerRef, NetworkObject>();
    public void PlayerJoined(PlayerRef player)
    {
        //if (player == Runner.LocalPlayer)
        //{
        //    Runner.Spawn(PlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
        //}
        Debug.Log($"[PLAYER JOINED] Player {player.PlayerId} joined. My role is Server: {Runner.IsServer}.");
        if (Runner.IsServer)
        {
            // 1. Spawn the object
            NetworkObject networkPlayerObject = Runner.Spawn(
                prefab: PlayerPrefab,
                position: new Vector3(0, 1, 0),
                rotation: Quaternion.identity,
                inputAuthority: player // <--- THIS IS THE CRITICAL LINE
            );

            // 2. Track the spawned object
            spawnedPlayer.Add(player, networkPlayerObject);

            Debug.Log($"[SERVER] Spawned player for {player.PlayerId} and assigned Input Authority.");
        }
    }

    public void PlayerLeft(PlayerRef player)
    {

    }
}
