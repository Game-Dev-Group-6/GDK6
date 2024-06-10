using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class wallActive : MonoBehaviour
{
    [SerializeField] pocicaCombatManager pocicaCombatManager;
    [SerializeField] DialogueManagerV2 dialogueManagerV2;
    [SerializeField] DialogueManagerV2 dialogueManagerV2_1;
    bool kanan, kiri, player, cameraShake, combatBegin;
    CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] GameObject wallKanan, wallKiri, batasKanan, batasKiri;
    delayTime2 delayTime2;
    [SerializeField] bool IsActive;
    // Start is called before the first frame update
    void Start()
    {
        wallKanan.transform.position = new Vector2(batasKanan.transform.position.x, wallKanan.transform.position.y);
        wallKiri.transform.position = new Vector2(batasKiri.transform.position.x, wallKiri.transform.position.y);
        cinemachineVirtualCamera = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        delayTime2 = GetComponent<delayTime2>();

    }
    // Update is called once per frame
    void Update()
    {
        CameraShake();
        WallActive();
        CombatBegin();
    }

    void WallActive()
    {
        if (IsActive)
        {
            wallKanan.SetActive(true);
            wallKiri.SetActive(true);

            if (!kanan && !kiri && !player)
            {
                if (delayTime2.Delay(3f))
                {
                    cinemachineVirtualCamera.Follow = wallKanan.transform;
                    kanan = true;
                }
            }
            if (kanan && !kiri && !player)
            {
                if (delayTime2.Delay(3f))
                {
                    cinemachineVirtualCamera.Follow = wallKiri.transform;
                    kiri = true;
                }
            }
            if (kanan && kiri && !player)
            {
                if (delayTime2.Delay(3f))
                {
                    cinemachineVirtualCamera.Follow = GameObject.FindWithTag("Player").transform;
                    dialogueManagerV2_1.TriggerStartDialogue();
                    IsActive = false;
                    kanan = false;
                    kiri = false;
                    player = false;
                    cameraShake = false;
                }
            }
        }
    }

    void CameraShake()
    {
        if (dialogueManagerV2.countSentences == dialogueManagerV2.countClickButton && !cameraShake)
        {
            FindAnyObjectByType<cameraShake>().CameraShake(3, 1);
            cameraShake = true;
            dialogueManagerV2.countSentences = 0;
        }
        if (cameraShake)
        {
            if (delayTime2.Delay(1))
            {
                IsActive = true;
                delayTime2.Timer = 0;
                cameraShake = false;
            }
        }
    }

    void CombatBegin()
    {
        if (dialogueManagerV2_1.countSentences == dialogueManagerV2_1.countClickButton)
        {
            if (!combatBegin)
            {
                pocicaCombatManager.begins = true;
                combatBegin = true;
            }
            if (cinemachineVirtualCamera.m_Lens.OrthographicSize <= 10)
            {
                cinemachineVirtualCamera.m_Lens.OrthographicSize += 0.1f;
            }
            if (cinemachineVirtualCamera.m_Lens.OrthographicSize > 10)
            {
                dialogueManagerV2_1.countSentences = 0;
                FindAnyObjectByType<movementController>().interactNPC = false;
            }
        }
    }
}
