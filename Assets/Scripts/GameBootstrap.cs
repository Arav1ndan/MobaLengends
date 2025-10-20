using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private NetworkRunner runner;
    [SerializeField] private InputManager inputManager;

    private async void Start()
    {
        runner.AddCallbacks(inputManager);

        var args = new StartGameArgs
        {
            GameMode = GameMode.Host,   // or Client          
        };

        await runner.StartGame(args);

        
        runner.ProvideInput = true;
    }
}

