using TMPro;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;

    public void submitName()
    {
        BasicSpawner.instance.SetPlayerName(nameInputField.text);

        gameObject.SetActive(false);
    }
}
