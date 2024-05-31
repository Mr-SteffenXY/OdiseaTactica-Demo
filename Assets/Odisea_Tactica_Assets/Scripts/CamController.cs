using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float rotationSpeed = 50f;

    private CinemachineOrbitalTransposer orbitalTransposer;

    void Start()
    {
        if (virtualCamera == null)
        {
            Debug.LogError("Virtual Camera not assigned.");
            return;
        }

        orbitalTransposer = virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        if (orbitalTransposer == null)
        {
            Debug.LogError("CinemachineOrbitalTransposer not found on the virtual camera.");
        }
    }

    void Update()
    {
        if (orbitalTransposer != null)
        {
            float horizontalInput = 0f;

            if (Input.GetKey(KeyCode.E))
            {
                horizontalInput = -1f;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                horizontalInput = 1f;
            }

            orbitalTransposer.m_XAxis.Value += horizontalInput * rotationSpeed * Time.deltaTime;
        }
    }
}
