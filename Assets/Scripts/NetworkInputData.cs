using Fusion;
using UnityEngine;
using UnityEngine.UI;

[System.Flags]
public enum MOBAButtons : uint
{
    None = 0,
    Ability1 = 1 << 0,
    Ability2 = 1 << 1,
    Ability3 = 1 << 2,
    Attack = 1 << 3,
}
public struct NetworkInputData : INetworkInput
{
    public Vector3 direction;
    public MOBAButtons buttons;

    //public void Set(MOBAButtons buttons, bool state)
    //{
    //    if (state)
    //        this.buttons |= buttons;
    //    else 
    //        this.buttons &= ~buttons;
    //}
    public bool IsDown(MOBAButtons button)
    {
        return (buttons & button) == button;
    }
  
    //public uint Buttons;
    //public bool IsDown(MOBAButtons b) => (Buttons & (uint)b) != 0;
}
