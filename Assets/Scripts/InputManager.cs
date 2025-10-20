using Fusion;
using UnityEngine;
using Fusion.Sockets;
using System.Collections.Generic;
using System;
using UnityEngine.UI;


public class InputManager : SimulationBehaviour , INetworkRunnerCallbacks, IBeforeUpdate
{
    [SerializeField] private Joystick uiJoystick;


  
    [SerializeField] private Button Ability1;
    [SerializeField] private Button Ability2;
    [SerializeField] private Button Ability3;

    //private byte _localButtonState = 0;
    private uint _localButtonState;
    public void SetJoystick(Joystick j) => uiJoystick = j;

    private void Start()
    {
        var runner = FindAnyObjectByType<NetworkRunner>();
        if (runner != null)
        {
            Debug.Log("Addin input callback");
            runner.AddCallbacks(this);
        }
        Ability1.onClick.AddListener(() => OnAbilityPressed(MOBAButtons.Ability1));
        Ability2.onClick.AddListener(() => OnAbilityPressed(MOBAButtons.Ability2));
        Ability3.onClick.AddListener(() => OnAbilityPressed(MOBAButtons.Ability3));
    }
    private void OnAbilityPressed(MOBAButtons ability)
    {
        Debug.Log($"Button pressed: {ability}");
        _localButtonState |= (uint)ability; // mark ability as pressed
    }


    void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
    {
        if (uiJoystick == null) return;

        Vector2 move = uiJoystick.Direction;

        NetworkInputData data = new NetworkInputData
        {
            direction = new Vector3(move.x, 0f, move.y),
            buttons = (MOBAButtons)_localButtonState
            //Buttons = _localButtonState
        };

        Debug.Log($" Sending input with buttons: {data.buttons}");

        input.Set(data);
        
        _localButtonState = 0;
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {

    }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {

    }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {

    }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {

    }
    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {

    }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {

    }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {

    }
    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {

    }
    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {

    }
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        //Debug.Log("[InputManager] Player joined");
    }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {

    }
    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {

    }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {

    }
    public void OnSceneLoadDone(NetworkRunner runner)
    {

    }
    public void OnSceneLoadStart(NetworkRunner runner)
    {

    }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {

    }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {

    }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {

    }

    void IBeforeUpdate.BeforeUpdate()
    {
        // 1. CLEAR previous state
       // _localButtonState = 0;

        // 2. CHECK current ability key presses (Q, W, E for desktop input)
        // If you are using UI buttons, this logic would instead be handled by UI button callbacks

        //if (UnityEngine.Input.GetKeyDown(KeyCode.Q)) // Desktop key Q
        //{
        //    _localButtonState |= (1 << NetworkInputData.MOBA_KEY_1);
        //    //Debug.Log("q is pressed");
        //}
        //if (UnityEngine.Input.GetKeyDown(KeyCode.W)) // Desktop key W
        //{
        //    _localButtonState |= (1 << NetworkInputData.MOBA_KEY_2);
        //    //Debug.Log("w is pressed");
        //}
        //if (UnityEngine.Input.GetKeyDown(KeyCode.E)) // Desktop key E
        //{
        //    _localButtonState |= (1 << NetworkInputData.MOBA_KEY_3);
        //}

        // --- MOBILE INPUT (Alternative method for mobile UI buttons) ---
        // If you're using UI buttons, they would call a public function on InputManager:
        // public void OnAbility1Pressed() => _localButtonState |= (1 << NetworkInputData.MOBA_KEY_1);
    }
}
