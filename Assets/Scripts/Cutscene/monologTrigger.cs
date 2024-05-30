using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monologTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] public int[] numberIndextSentences;

    public void MonologTrigger()
    {
        dialogueManager.TriggerStartDialogue(numberIndextSentences);
    }

}
