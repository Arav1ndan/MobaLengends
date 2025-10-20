using Fusion;
using UnityEngine;
using static Unity.Collections.Unicode;

public struct AbilityData : INetworkStruct
{
    // Cooldown
    public TickTimer CooldownTimer;
    public float BaseCooldown; // The max cooldown value in seconds

    // Leveling & Damage
    public int CurrentLevel;
    public float BaseDamage;
    public float DamagePerLevel;

    // A flag to check if the ability is ready to be cast
    public bool IsReady(NetworkRunner runner)
    {
        // Now you use the passed-in runner instance
        return CooldownTimer.ExpiredOrNotRunning(runner);
    }
    public float GetCurrentDamage(int currentHeroLevel)
    {
        return BaseDamage + (DamagePerLevel * currentHeroLevel);
    }
}
