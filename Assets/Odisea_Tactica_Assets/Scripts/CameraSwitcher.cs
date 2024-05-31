using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras;

    private CinemachineVirtualCamera currentCamera;

    void Start()
    {
        if (virtualCameras.Length > 0)
        {
            currentCamera = virtualCameras[0];
            SetActiveCamera(currentCamera);
        }
    }

    public void SwitchToCamera(int cameraIndex)
    {
        if (cameraIndex >= 0 && cameraIndex < virtualCameras.Length)
        {
            SetActiveCamera(virtualCameras[cameraIndex]);
        }
    }

    private void SetActiveCamera(CinemachineVirtualCamera newCamera)
    {
        if (currentCamera != null)
        {
            currentCamera.Priority = 0;
        }

        newCamera.Priority = 10;
        currentCamera = newCamera;
    }
}
