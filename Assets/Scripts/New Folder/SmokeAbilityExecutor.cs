using Fusion;
using UnityEngine;

// 💨 Executor: Responsible only for the Smoke Grenade's specific effect logic.
public class SmokeAbilityExecutor : NetworkBehaviour
{
    public void Execute(AbilityData data)
    {
        // Logic specific to the Smoke Grenade (e.g., spawning a persistent smoke cloud)

        // 1. Spawn a networked smoke cloud object at target location.
        // 2. The smoke cloud grants the 'Smoke' buff/debuff to units inside its radius.

        Debug.Log($"Smoke deployed!");
    }
}