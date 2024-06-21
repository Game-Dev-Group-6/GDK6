using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class timeline1 : MonoBehaviour
{

    [SerializeField] DialogueManagerV2 dialogueManagerV2;
    GameObject player;
    [SerializeField] Transform shotCameraInPlayer;
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    delayTime2 delayTime2;
    bool timelineActive;
    // Start is called before the first frame update
    void Start()
    {
        delayTime2 = GetComponent<delayTime2>();
        cinemachineVirtualCamera = GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame

    void Update()
    {
        if (timelineActive)
        {
            player.GetComponent<movementController>().interactNPC = true;
            cinemachineVirtualCamera.Follow = shotCameraInPlayer;
            if (delayTime2.Delay(2.5f))
            {
                playableDirector.Play();
                timelineActive = false;
            }
        }
    }
    int i = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (i < 1)
        {
            if (other.tag == "Player")
            {
                PlayerPrefs.SetInt("Kunta", 2);
                timelineActive = true;
                PlayerPrefs.SetString("ShowTrashInHutanRoh", "");
                i++;
            }
        }

    }
    public void CameraBackToPlayer()
    {
        cinemachineVirtualCamera.Follow = player.transform;
        dialogueManagerV2.TriggerStartDialogue();
        /*  player.GetComponent<movementController>().interactNPC = false; */
    }

    public void ShowTrashInJalurHutan()
    {
        PlayerPrefs.SetString("ShowTrashInJalurHutan", "");
    }
}
