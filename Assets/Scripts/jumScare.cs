using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class jumScare : MonoBehaviour
{
    movementController movementController;
    bool firstTrigger;
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] GameObject[] pocica;
    [SerializeField] bool CutScene;
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
        movementController = FindAnyObjectByType<movementController>();
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
        if (CutScene)
        {
            if (delayTime2.Delay(0.5f))
            {
                if (playableDirector != null)
                {
                    foreach (GameObject pocicas in pocica)
                    {
                        pocicas.SetActive(true);
                    }
                    playableDirector.Play();
                    CutScene = false;
                    delayTime2.Timer = 0;
                    movementController.interactNPC = false;
                }
            }
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
                CutScene = true;
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
        if (other.tag == "Player" && !firstTrigger)
        {
            firstTrigger = true;
            movementController.interactNPC = true;
            FindAnyObjectByType<movementController>().interactNPC = true;
            isJumpScare = true;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1.8f;
            background.SetActive(true);
            UIHide.SetActive(false);
        }
    }

}
