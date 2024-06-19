using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs4 : MonoBehaviour
{
    [SerializeField] DialogueManagerV2 dialogueManagerV2;
    [SerializeField] delayTime2 delayTime2;
    bool triggerDialogue;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("Klue3"))
        {
            FindAnyObjectByType<clueButton>().klueBaru = true;
            PlayerPrefs.SetString("Klue3", "");
        }
        if (PlayerPrefs.HasKey("AfterMelati"))
        {
            if (!PlayerPrefs.HasKey("AfterMelatiOutTent"))
            {
                triggerDialogue = true;
                FindAnyObjectByType<clueButton>().klueBaru = true;
                PlayerPrefs.SetString("Klue6", "");
            }
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (triggerDialogue)
        {
            if (delayTime2.Delay(1f))
            {
                TriggerDialogue2();
                triggerDialogue = false;
                PlayerPrefs.SetString("AfterMelatiOutTent", "");
            }
        }
    }
    void TriggerDialogue2()
    {
        dialogueManagerV2.TriggerStartDialogue();
    }
}
