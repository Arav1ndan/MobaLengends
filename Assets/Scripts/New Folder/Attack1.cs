using Fusion;
using System;
using UnityEngine;

public class Attack1 : NetworkBehaviour
{
    [SerializeField] private float Damage = 10.0f;
    [SerializeField] private CollitionCheckPlayer collitionCheckPlayer;

    private void Start()
    {
        collitionCheckPlayer = GetComponent<CollitionCheckPlayer>();
    }

    public override void FixedUpdateNetwork()
    {
        if(HasStateAuthority == false)
        {
            return;
        }
        if (GetInput(out NetworkInputData input))
        {
            Debug.Log($" Received input buttons: {input.buttons}");
            ProcessInput(input);
        }
       


    }  
    void PerformAttack()
    {
        var target = collitionCheckPlayer.ReturnPlayerInsideSphere();
        if (target != null)
        {
            var health = target.GetComponent<Health>();
            if (health != null)
            {
                health.DealDamageRpc(Damage);
            }
        }
        else
        {
            Debug.Log("target is null");
        }
    }
    public void ProcessInput(NetworkInputData input)
    {
        if (input.IsDown(MOBAButtons.Ability1))
        {
            Debug.Log("button 1 pressed for ability. now ability have to work");
            //UseAbility1();
            PerformAttack();
        }
        if (input.IsDown(MOBAButtons.Ability2))
        {
            Debug.Log("button 2 pressed for ability. now ability have to work");
            UseAbility2();
        }
        if (input.IsDown(MOBAButtons.Ability3))
        {
            Debug.Log("button 3 pressed for ability. now ability have to work");
            UseAbility3();
        }
    }

    private void UseAbility3()
    {
        Debug.Log("Ability 3 used");
    }

    private void UseAbility2()
    {
        Debug.Log("Ability 2 used");
    }

    private void UseAbility1()
    {
        Debug.Log("Ability 1 used");
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(playerCenter ? playerCenter.position : transform.position, attackRadius);
    //}
}
