using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class jumScare : MonoBehaviour
{
    [SerializeField] DialogueManagerV2 dialogueManagerV2;
    [SerializeField] kuntaAfterPocica kuntaAfterPocica;
    [SerializeField] bool afterJumpNotScarePlayTimeline;
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
    BoxCollider2D colliders;
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
        colliders = GetComponent<BoxCollider2D>();
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
                }
            }
        }
        DeletePlayerPrefsKunta();
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
                if (!afterJumpNotScarePlayTimeline)
                {
                    CutScene = true;
                }
                if (afterJumpNotScarePlayTimeline)
                {
                    kuntaAfterPocica.makeVisible = true;
                }
                isJumpScare = false;
                scaleSprite = 0;
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
                background.SetActive(false);
                UIHide.SetActive(true);
            }
        }
        sprite.transform.localScale = new Vector2(scaleSprite, scaleSprite);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !firstTrigger)
        {
            if (colliders != null)
            {
                colliders.enabled = false;
            }
            firstTrigger = true;
            movementController.interactNPC = true;
            isJumpScare = true;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 10f;
            background.SetActive(true);
            UIHide.SetActive(false);
        }
    }

    void DeletePlayerPrefsKunta()
    {
        if (dialogueManagerV2 != null)
        {
            if (dialogueManagerV2.countClickButton == dialogueManagerV2.countSentences)
            {
                PlayerPrefs.DeleteKey("Kunta3");
                PlayerPrefs.SetString("Kunta2Delete", "");
                FindAnyObjectByType<clueButton>().klueBaru = true;
                PlayerPrefs.SetString("Klue8", "");
                dialogueManagerV2.countClickButton = 0;
            }
        }

    }

}
