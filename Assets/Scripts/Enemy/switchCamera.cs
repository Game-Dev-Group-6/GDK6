using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class switchCamera : MonoBehaviour
{
    handAttack handAttack;
    public bool backToPlayer = false;
    GameObject[] cameraa;
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    public void LookGraveyard()
    {
        handAttack = GetComponent<handAttack>();
        handAttack.startCombat = true;
        virtualCamera.Follow = gameObject.transform;
    }
    public void LookPlayer()
    {
        virtualCamera.Follow = GameObject.Find("Player").transform;
        backToPlayer = true;
    }
}
