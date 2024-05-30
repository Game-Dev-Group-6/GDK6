using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] int[] showSentences;
    public enum TypeInteract
    {
        Monolog, Dialogue
    }
    bool dialog;
    public TypeInteract selectTypeInteract;

    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private bool PlayerSpeakingFirst;

    [Header("Dialogue TMP Text")]
    [SerializeField] private TextMeshProUGUI playerDialogueText;
    [SerializeField] private TextMeshProUGUI nPCDialogueText;

    [Header("Continue Buttons")]
    [SerializeField] private GameObject playerContinueButton;
    [SerializeField] private GameObject nPCContinueButton;
    [SerializeField] private GameObject playerContinueButtonMonolog;

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

    public bool startActionAfterDialog = false;
    private int countClickButton = 0;
    private bool dialogueStarted;

    [SerializeField] private int playerIndex;
    [SerializeField] private int nPCIndex;
    [SerializeField] private int playerIndexMonolog;

    private float speechBubbleAnimationDelay = 0.6f;

    private void Start()
    {
        playerMovementScript = FindObjectOfType<movementController>();
        SelectTypeInteract();
    }

    public void TriggerStartDialogue(int[] selectSentences)
    {
        if (dialog)
        {
            StartCoroutine(StartDialogue());
        }
        else if (!dialog)
        {
            showSentences = selectSentences;
            StartCoroutine(StartMonolog());
        }

    }

    private void Update()
    {
        if (playerContinueButton != null)
        {
            if (playerContinueButton.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                    TriggerContinueNPCDialogue();
            }
        }


        if (nPCContinueButton != null)
        {
            if (nPCContinueButton.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                    TriggerContinuePlayerDialogue();
            }
        }


        if (countClickButton == playerDialogueSentences.Length + nPCDialogueSentences.Length)
        {
            startActionAfterDialog = true;
        }

    }

    private IEnumerator StartDialogue()
    {

        playerMovementScript.ToggleInteraction();

        if (PlayerSpeakingFirst)
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

        foreach (char letter in playerDialogueSentences[playerIndex].ToCharArray())
        {
            playerDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        playerContinueButton.SetActive(true);
    }

    private IEnumerator TypeNPCDialogue()
    {

        foreach (char letter in nPCDialogueSentences[nPCIndex].ToCharArray())
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

        if (dialogueStarted)
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

        Debug.Log("TriggerContinuePlayerDialog");

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

        Debug.Log("TriggerContinueNPCDialogu");

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


    private IEnumerator StartMonolog()
    {
        playerMovementScript.ToggleInteraction();
        playerSpeechBubbleAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(speechBubbleAnimationDelay);
        StartCoroutine(TypePlayerMonolog());
    }
    public void TriggerContinuePlayerMonolog()
    {
        Debug.Log("TriggerContinuePlayerMonolog");
        playerContinueButtonMonolog.SetActive(false);
        uIAudioSource.Play();

        if (playerIndexMonolog >= showSentences.Length - 1)
        {
            playerDialogueText.text = "";
            playerSpeechBubbleAnimator.SetTrigger("Close");
            playerMovementScript.ToggleInteraction();
            playerIndexMonolog = 0;
            showSentences = null;
        }
        else
        {
            StartCoroutine(ContinuePlayerMonolog());
            playerIndexMonolog++;
        }
    }
    private IEnumerator ContinuePlayerMonolog()
    {
        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        playerDialogueText.text = "";
        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        StartCoroutine(TypePlayerMonolog());
    }
    private IEnumerator TypePlayerMonolog()
    {
        int lenghtChar = 1;
        foreach (char letter in playerDialogueSentences[showSentences[playerIndexMonolog]].ToCharArray())
        {
            playerDialogueText.text += letter;
            lenghtChar++;
            yield return new WaitForSeconds(typingSpeed);
        }
        if (lenghtChar >= playerDialogueSentences[showSentences[playerIndexMonolog]].ToCharArray().Length)
        {
            playerContinueButtonMonolog.SetActive(true);
        }

    }



    public void CountClickButton()
    {
        countClickButton++;
        Debug.Log("countClickButtonIsAdd");
    }

    void SelectTypeInteract()
    {
        switch (selectTypeInteract)
        {
            case TypeInteract.Monolog:
                dialog = false;
                break;
            case TypeInteract.Dialogue:
                dialog = true;
                break;
        }
    }


}
