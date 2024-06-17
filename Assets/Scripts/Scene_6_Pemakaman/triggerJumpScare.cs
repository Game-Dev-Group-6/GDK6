using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class triggerJumpScare : MonoBehaviour
{
    [SerializeField] float speedZoom;
    float scaleSprite = 0;
    CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject sprite, background;
    bool oneTriggerJumpScare, isJumpScare;
    delayTime2 delayTime2;
    [SerializeField] GameObject UIHide;
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        delayTime2 = GetComponent<delayTime2>();
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
            }
        }
        sprite.transform.localScale = new Vector2(scaleSprite, scaleSprite);
    }
    void JumpScareActive()
    {
        background.SetActive(true);
        UIHide.SetActive(false);
        isJumpScare = true;
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1.8f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !oneTriggerJumpScare)
        {
            JumpScareActive();
            oneTriggerJumpScare = true;
        }
    }
}
