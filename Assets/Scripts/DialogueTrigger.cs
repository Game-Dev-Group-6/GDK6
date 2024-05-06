using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;

    private bool triggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            //Start Dialogue
            dialogueManager.TriggerStartDialogue();
            triggered = true;
        }
        
    }
}
