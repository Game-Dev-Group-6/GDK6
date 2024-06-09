using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class jumScare : MonoBehaviour
{
    [SerializeField] GameObject UIHide;
    [SerializeField] GameObject sprite, background;
    [SerializeField] delayTime2 delayTime2;
    bool isJumpScare = false;
    float scaleSprite = 0;
    [SerializeField] float speedZoom;
    CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Awake()
    {
        sprite.transform.localScale = Vector2.zero;
        virtualCamera = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isJumpScare)
        {
            ZoomCamera();
        }
    }

    void ZoomCamera()
    {
        if (scaleSprite < 0.35f)
        {
            scaleSprite += speedZoom * Time.deltaTime;
        }
        if (scaleSprite >= 0.35f)
        {
            if (delayTime2.Delay(1.3f))
            {
                isJumpScare = false;
                scaleSprite = 0;
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
                background.SetActive(false);
                UIHide.SetActive(true);
                FindAnyObjectByType<movementController>().interactNPC = false;
            }
        }
        sprite.transform.localScale = new Vector2(scaleSprite, scaleSprite);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindAnyObjectByType<movementController>().interactNPC = true;
            isJumpScare = true;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1.8f;
            background.SetActive(true);
            UIHide.SetActive(false);
        }
    }

}
