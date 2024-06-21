using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class virtualCameraMissing : MonoBehaviour
{
    CinemachineVirtualCamera cinemachineVirtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    // Update is called once per frame
    void Update()
    {
        if (cinemachineVirtualCamera.Follow == null)
        {
            cinemachineVirtualCamera.Follow = GameObject.FindWithTag("Player").transform;
        }
    }
}
