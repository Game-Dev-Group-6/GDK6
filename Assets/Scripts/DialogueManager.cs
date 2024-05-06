using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private bool PlayerSpeakingFirst;

    [Header("Dialogue TMP Text")]
    [SerializeField] private TextMeshProUGUI playerDialogueText;
    [SerializeField] private TextMeshProUGUI nPCDialogueText;

    [Header("Continue Buttons")]
    [SerializeField] private GameObject playerContinueButton;
    [SerializeField] private GameObject nPCContinueButton;

    [Header("Animation Controllers")]
    [SerializeField] private Animator playerSpeechBubbleAnimator;
    [SerializeField] private Animator nPCSpeechBubbleAnimator;

    [Header("Click Next Audio")]
    [SerializeField] private AudioSource uIAudioSource;

    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] playerDialogueSentences;
    [TextArea]
    [SerializeField] private string[] nPCDialogueSentences;

    private movementController playerMovementScript;

    private bool dialogueStarted;

    private int playerIndex;
    private int nPCIndex;

    private float speechBubbleAnimationDelay = 0.6f;

    private void Start()
    {
        playerMovementScript = FindObjectOfType<movementController>();
    }

    public void TriggerStartDialogue()
    {
        StartCoroutine(StartDialogue());
    }

    private void Update()
    {
        if (playerContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                TriggerContinueNPCDialogue();
        }

        if (nPCContinueButton.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                TriggerContinuePlayerDialogue();
        }
    }

    private IEnumerator StartDialogue()
    {

        playerMovementScript.ToggleInteraction();

        if(PlayerSpeakingFirst)
        {
            playerSpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypePlayerDialogue());
        }
        else
        {
            nPCSpeechBubbleAnimator.SetTrigger("Open");

            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeNPCDialogue());
        }
    }

    private IEnumerator TypePlayerDialogue()
    {
        foreach(char letter in playerDialogueSentences[playerIndex].ToCharArray())
        {
            playerDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        playerContinueButton.SetActive(true);
    }

    private IEnumerator TypeNPCDialogue()
    {
        foreach(char letter in nPCDialogueSentences[nPCIndex].ToCharArray())
        {
            nPCDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        nPCContinueButton.SetActive(true);
    }

    private IEnumerator ContinuePlayerDialogue()
    {
        nPCDialogueText.text = "";

        nPCSpeechBubbleAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        playerDialogueText.text = "";

        playerSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        
        if(dialogueStarted)
            playerIndex++;
        else
            dialogueStarted = true;
        
        StartCoroutine(TypePlayerDialogue());
        
    }

    private IEnumerator ContinueNPCDialogue()
    {

        playerDialogueText.text = "";

        playerSpeechBubbleAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        nPCDialogueText.text = "";

        nPCSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        
        if (dialogueStarted)
            nPCIndex++;
        else
            dialogueStarted = true;
            
        StartCoroutine(TypeNPCDialogue());
        
    }

    public void TriggerContinuePlayerDialogue()
    {
        uIAudioSource.Play();

        nPCContinueButton.SetActive(false);

        if (playerIndex >= playerDialogueSentences.Length - 1)
        {
            nPCDialogueText.text = "";

            nPCSpeechBubbleAnimator.SetTrigger("Close");

            playerMovementScript.ToggleInteraction();
        }
        else
            StartCoroutine(ContinuePlayerDialogue());
    }

    public void TriggerContinueNPCDialogue()
    {
        uIAudioSource.Play();

        playerContinueButton.SetActive(false);

        if (nPCIndex >= nPCDialogueSentences.Length - 1)
        {
            playerDialogueText.text = "";

            playerSpeechBubbleAnimator.SetTrigger("Close");

            playerMovementScript.ToggleInteraction();
        }
        else
            StartCoroutine(ContinueNPCDialogue());
    }
}
