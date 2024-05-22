using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class switchCamera : MonoBehaviour
{
    float xOffset;
    bool followPlayer = false;
    public bool startCombat = true;
    GameObject gendoruwo;
    enemyTrigger enemyTrigger;
    handAttack handAttack;
    public bool backToPlayer = false;
    GameObject[] cameraa;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    movementController movementController;

    void Start()
    {
        gendoruwo = GameObject.Find("Enemy_Gendoruwo");
        enemyTrigger = GameObject.Find("RangeTriggerGendoruwo").GetComponent<enemyTrigger>();
        movementController = FindAnyObjectByType<movementController>();
    }
    void Update()
    {
        if (virtualCamera.transform.position.x > gendoruwo.transform.position.x - 5)
        {
            if (backToPlayer)
            {
                if (startCombat)
                {
                    enemyTrigger.combatBegin = true;
                    gendoruwo.GetComponent<combat>().startCombat = true;
                    startCombat = false;
                }
            }
        }
        if (followPlayer)
        {
            if (virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x < 2)
            {
                virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x += 0.01f;
                if (virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x > 1.2)
                {
                    movementController.interactNPC = false;
                }
            }
        }
    }
    public void LookGraveyard()
    {
        movementController.interactNPC = true;
        handAttack = GetComponent<handAttack>();
        handAttack.startCombat = true;
        virtualCamera.Follow = gameObject.transform;
    }
    public void LookPlayer()
    {
        followPlayer = true;
        virtualCamera.Follow = GameObject.Find("Player").transform;
        backToPlayer = true;
    }

    public void LookEnemy()//Dipanggil pada animasi Graveyard
    {
        movementController.interactNPC = true;

        virtualCamera.Follow = gendoruwo.transform;
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = -3;
        backToPlayer = true;
    }
}
