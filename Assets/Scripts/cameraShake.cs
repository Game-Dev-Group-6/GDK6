using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    [SerializeField]CinemachineVirtualCamera cam;
    CinemachineBasicMultiChannelPerlin channel;
    float time;
    [SerializeField] float shakeIntensity;
    [SerializeField] float shakeTime;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera> ();
        CameraStop ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            CameraShake();
            
        }else if (time > 0){
            time -= Time.deltaTime;
            if(time <= 0)
            {
                CameraStop();
            }
        }
    }
    void CameraShake()
    {
        channel = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        channel.m_AmplitudeGain = shakeIntensity;
        time = shakeTime;
    }
    void CameraStop()
    {
        channel = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        channel.m_AmplitudeGain = 0;
    }
}
