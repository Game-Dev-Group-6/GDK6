using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class playerPrefs2 : MonoBehaviour
{
    static GameObject virtualCamera;
    static GameObject player;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        virtualCamera = GameObject.FindWithTag("VirtualCamera");
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("Scene2CamOffX"))
        {
            virtualCamera.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.x = PlayerPrefs.GetFloat("Scene2CamOffX");
        }
        player.GetComponent<SpriteRenderer>().flipX = PlayerPrefs.GetInt("flipX", 0) == 1;
    }
    public static void SetPosPlayer(float posXKurang)
    {


    }
    public static void SetCamOffX(float posX)
    {
        if (virtualCamera != null)
        {
            PlayerPrefs.SetFloat("Scene2CamOffX", posX);
        }

    }
}
