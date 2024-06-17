using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class triggerDeadZoneVirtualCam_1 : MonoBehaviour
{
    public enum DeadZonePos
    {
        leftPlayer,
        rightPlayer,
    }
    public DeadZonePos deadZonePos;
    bool deadZoneActive = false;
    GameObject player;
    CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cam = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        TriggerDeadZone();
    }

    void TriggerDeadZone()
    {

        switch (deadZonePos)
        {
            case DeadZonePos.leftPlayer:
                DeadZoneLeftPlayer();
                break;

            case DeadZonePos.rightPlayer:
                DeadZoneRightPlayer();
                break;
        }
    }

    void DeadZoneLeftPlayer()
    {
        if (player.transform.position.x < transform.position.x)
        {
            cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneWidth = 2;
            deadZoneActive = true;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            if (deadZoneActive)
            {
                cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.x = 0;
                cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneWidth = 0;
                deadZoneActive = false;
            }

        }
    }
    void DeadZoneRightPlayer()
    {
        if (player.transform.position.x < transform.position.x)
        {
            if (deadZoneActive)
            {
                cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneWidth = 0;
                cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.x = 0;
                deadZoneActive = false;
            }

        }
        else if (player.transform.position.x > transform.position.x)
        {
            cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneWidth = 2;
            deadZoneActive = true;
        }
    }
}
