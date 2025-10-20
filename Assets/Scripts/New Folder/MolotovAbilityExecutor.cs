using Fusion;
using System.Collections;
using UnityEngine;


    public class MolotovAbilityExecutor : NetworkBehaviour
    {
        public void Execute(AbilityData data)
        {
            // Logic specific to Molotov (e.g., throwing a projectile, dealing damage)
            float damageToDeal = data.GetCurrentDamage(GetComponent<HeroAbilityController>().HeroLevel);

            // 1. Instantiate the Molotov projectile on the network (RPC or Networked Object spawn)
            // 2. The projectile handles its collision and applies the 'damageToDeal' to enemies in its area.

            Debug.Log($"Molotov launched! Dealing {damageToDeal} damage.");
        }
    }