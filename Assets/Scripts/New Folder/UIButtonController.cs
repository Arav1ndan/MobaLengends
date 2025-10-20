using UnityEngine;
using Fusion;
public class UIButtonController : MonoBehaviour
{
    private HeroAbilityController _localAbilityControllr;

    public void callAbility1()
    {
        if(EnsureLocalAbilityController())
        {
            _localAbilityControllr.OnAbility1UIButton();
        }
    }
    public void callAbility2()
    {
        if (EnsureLocalAbilityController())
            _localAbilityControllr.OnAbility2UIButton();
    }
    public void callAbility3()
    {
        if (EnsureLocalAbilityController())
            _localAbilityControllr.OnAbility3UIButton();
    }
    public void SetLocalController(HeroAbilityController controller)
    {
        _localAbilityControllr = controller;
        Debug.Log("UI Connector successfully linked to local player's HeroAbilityController.");
    }

    private bool EnsureLocalAbilityController()
    {
        if(_localAbilityControllr == null)
        {
            Debug.Log("hero ability controler is null");
            return false;
        }
        return true;
    }
}
