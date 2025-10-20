using TMPro;
using UnityEngine;

public class EnterPlayerName : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private GameObject ControllerCanvase;
    TouchScreenKeyboard keyboard;
    void OpenKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
    public void submitName()
    {
        OpenKeyboard();
        BasicSpawner.instance.SetPlayerName(nameInputField.text);

        gameObject.SetActive(false);
        ControllerCanvase.SetActive(true);
    }
}
