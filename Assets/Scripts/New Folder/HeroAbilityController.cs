using Fusion;
using UnityEngine;

public class HeroAbilityController : NetworkBehaviour
{ // The player's main level will influence all abilities' damage/effects
    [Networked]
    public int HeroLevel { get; set; } = 1;

    // Networked struct for each of your 3 abilities (Molotov, Smoke, etc.)
    
    public AbilityData Ability1;
    
    public AbilityData Ability2;
    public AbilityData Ability3;


    private uint _localButtonState;

    // --- Start/Setup Logic ---
    public override void Spawned()
    {
        // Initialize Ability 1 (e.g., Molotov)
        Ability1 = new AbilityData
        {
            BaseCooldown = 12.0f,
            BaseDamage = 50.0f,
            DamagePerLevel = 25.0f,
            CurrentLevel = 1
        };

        Ability2 = new AbilityData
        {
            BaseCooldown = 1.0f,
            BaseDamage = 50.0f,
            DamagePerLevel = 25.0f,
            CurrentLevel = 1
        };
        // Initialize Ability 2 (e.g., Smoke Grenade)
        // ...
    }
    public void OnAbility1UIButton()
    {
        Debug.Log("UI Ability 1 clicked");
        _localButtonState |= (uint)MOBAButtons.Ability1;

    }
    public void OnAbility2UIButton()
    {
        Debug.Log("UI Ability 2 clicked");
        _localButtonState |= (uint)MOBAButtons.Ability2;
    }
    public void OnAbility3UIButton()
    {
        Debug.Log("UI Ability 3 clicked");
        _localButtonState |= (uint)MOBAButtons.Ability3;
    }
    // --- Input & Casting Logic ---
    public override void FixedUpdateNetwork()
    {
        // Only the client with input authority should run this
        if (!Object.HasInputAuthority) return;   // <-- important guard
        //Debug.Log($"[HeroAbilityController] FixedUpdateNetwork tick {Runner.Tick}");


        if (GetInput(out NetworkInputData data))
        {
            //Debug.Log($"[HeroAbilityController] Buttons value: {data.Buttons}");

            //if (data.Buttons > 0)
            //{
            //    // This confirms input with a button press reached the server/host
            //    Debug.Log($"[SERVER/HOST] Received Input Tick {Runner.Tick}. Raw Buttons: {data.Buttons}");
            //}
            //if (data.IsDown(NetworkInputData.MOBA_KEY_1))
            //{
            //    Debug.Log("ability one is working");
            //    TryCastAbility(ref Ability1, 1,Runner);

            //}
            //if (data.IsDown(NetworkInputData.MOBA_KEY_2))
            //{
            //    TryCastAbility(ref Ability2, 2, Runner);
            //}
            //if(data.IsDown(NetworkInputData.MOBA_KEY_3))
            //{
            //    TryCastAbility(ref Ability3 , 3, Runner);  
            //}
           
        }
    }

    private void TryCastAbility(ref AbilityData ability, int abilityIndex,NetworkRunner runner)
    {
        if (ability.IsReady(runner))
        {
            // Set the cooldown timer
            ability.CooldownTimer = TickTimer.CreateFromSeconds(Runner, ability.BaseCooldown);

            // Call the execution logic (explained in the next section)
            ExecuteAbility(abilityIndex, ability);
        }
    }

    // This method will be implemented by a separate execution component
    // SOLID: Dependency Inversion/Open-Closed - Decouple casting from execution
    private void ExecuteAbility(int abilityIndex, AbilityData data)
    {
        // This is where you call the specialized component to handle the specific effect
        // Example: GetComponent<MolotovAbilityExecutor>().Execute(data);
        Debug.Log($"Ability {abilityIndex} cast! Damage: {data.GetCurrentDamage(HeroLevel)}");
        switch (abilityIndex)
        {
            case 1:
                GetComponent<MolotovAbilityExecutor>().Execute(data);
                break;
            case 2:
                GetComponent<SmokeAbilityExecutor>().Execute(data);
                break;
                // ... add new cases without modifying the existing ones
        }
    }

}
