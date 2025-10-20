using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private GameObject mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main.gameObject;
    }

    private void Update()
    {
       transform.LookAt(mainCamera.transform);
    }
}
