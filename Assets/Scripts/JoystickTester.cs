
using UnityEngine;


    public class JoystickTester : MonoBehaviour
    {

    [SerializeField] private Joystick joystick;

    void Update()
    {
        // Print to console to see live values
        //Debug.Log($"Horizontal: {joystick.Horizontal:F2}  Vertical: {joystick.Vertical:F2}");
    }
}
