using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(HealthChanged))]
    public float NetworkedHealth { get; set; } = 100;

    [SerializeField] private Slider healthSlider;
    void HealthChanged()
    {
        Debug.Log($"Health changed to: {NetworkedHealth}");
        //PlayerHealth.value = NetworkedHealth;
        UpdateHealthBar();
    }
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void DealDamageRpc(float damage)
    {
        // The code inside here will run on the client which owns this object (has state and input authority).
        Debug.Log("Received DealDamageRpc on StateAuthority, modifying Networked variable");
        NetworkedHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage! Remaining: {NetworkedHealth}");
        if (NetworkedHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = NetworkedHealth;
        }
    }
}
