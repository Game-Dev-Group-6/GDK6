using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManagerV2 dialogueManagerV2;
    [SerializeField] private DialogueManager dialogueManager;

    private bool triggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (dialogueManagerV2 != null)
        {
            if (other.CompareTag("Player") && !triggered)
            {
                //Start Dialogue
                dialogueManagerV2.TriggerStartDialogue();
                triggered = true;
            }
        }
        if (dialogueManager != null)
        {
            if (other.CompareTag("Player") && !triggered)
            {
                //Start Dialogue
                dialogueManager.TriggerStartDialogue(null);
                triggered = true;
            }
        }

    }
}
