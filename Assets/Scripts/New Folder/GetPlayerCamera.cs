using UnityEngine;
using Unity.Cinemachine;
using Fusion;

public class GetPlayerCamera : MonoBehaviour
{
    [SerializeField] Transform playerCameraRoot;

    private void LateUpdate()
    {
        NetworkObject thisObj = GetComponent<NetworkObject>();

        if (thisObj.HasStateAuthority)
        {
            GameObject virtualCamera = GameObject.Find("PlayerFollowCamera");
            virtualCamera.GetComponent<CinemachineCamera>().Follow = playerCameraRoot;

            GetComponent<PlayerMovement>().enabled = true;
        }
    }

}
