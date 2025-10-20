using UnityEngine;
using Unity.Cinemachine;
using Fusion;

public class getPlayerCameraFollow : NetworkBehaviour
{
    //for now let's use this we've to rename this script into 3rd personfollow camera.

    public Transform Target;
    public CinemachineCamera _camera;

    public override void Spawned()
    {
        if(Object.HasInputAuthority)
        {
            GameObject cameraObj = GameObject.Find("PlayerFollowCamera");
            GetComponent<PlayerMovement>().enabled = true;
            if (cameraObj != null)
            {
                _camera = cameraObj.GetComponent<CinemachineCamera>();

            }

            // 2. Set the follow target immediately in Spawned()
            if (_camera != null)
            {
                _camera.Follow = Target;

                // You can enable the movement component here as well
                
            }
        }
    }
}

