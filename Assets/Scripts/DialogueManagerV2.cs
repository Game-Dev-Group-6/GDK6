using System;
using TMPro;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


[Serializable]
public class Array2d
{
    [TextArea][SerializeField] public string[] sentences;
}
public class DialogueManagerV2 : MonoBehaviour
{

    [SerializeField] AudioSource audioPlayer, audioNPC;

    [Header("Dialogue Sentences")]
    [SerializeField] Array2d[] playerSentences;
    [SerializeField] Array2d[] npcSentences;
    [SerializeField] int[] showSentences;
    public enum TypeInteract
    {
        Monolog, Dialogue
    }
    [SerializeField] bool Monolog;
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


    [SerializeField] GameObject UIhide;

    private movementController playerMovementScript;

    public bool events = false, setEventFalse = false;
    [SerializeField] public int countClickButton = 0;
    [SerializeField] private int playerIndexI = 0;
    [SerializeField] private int playerIndexJ = 0;
    [SerializeField] public int nPCIndexI = 0;
    [SerializeField] public int nPCIndexJ = 0;
    public static bool isInteract = false;
    [SerializeField] public int countSentences;
    private float speechBubbleAnimationDelay = 0.6f;
    [SerializeField] bool nextDialogue;
    [SerializeField] bool klueActive;
    [SerializeField] bool makePlayerPrefsGamePlay;
    [SerializeField] bool interactNPCMakeTrueInLast;


    private void Start()
    {
        if (PlayerSpeakingFirst)
        {
            nPCIndexI = -1;
        }
        else if (!PlayerSpeakingFirst)
        {
            playerIndexI = -1;
        }
        playerMovementScript = FindObjectOfType<movementController>();
        CountSentences();
    }

    public void TriggerStartDialogue()
    {
        isInteract = true;
        StartCoroutine(StartDialogue());
        HideUI();
    }

    private void Update()
    {
        if (playerContinueButton != null)
        {
            if (playerContinueButton.activeSelf)
            {
                if (Input.anyKeyDown && nextDialogue)
                {
                    Debug.Log("keyretur");
                    TriggerContinueNPCDialogue();
                }

            }

        }


        if (nPCContinueButton != null)
        {
            if (nPCContinueButton.activeSelf)
            {
                if (Input.anyKeyDown && nextDialogue)
                {
                    TriggerContinuePlayerDialogue();
                }

            }
        }


        if (countClickButton == countSentences)
        {
            if (nPCDialogueText != null)
            {
                nPCDialogueText.text = "";
            }
            if (playerDialogueText != null)
            {
                playerDialogueText.text = "";
            }
            if (makePlayerPrefsGamePlay)
            {
                PlayerPrefs.SetString("GamePlay", "");
            }
            if (Monolog)
            {
                countClickButton = 0;
                playerIndexI = 0;
                playerIndexJ = 0;
                nPCIndexI = -1;
            }
            UnHideUI();
            if (!interactNPCMakeTrueInLast)
            {
                playerMovementScript.interactNPC = false;
            }
            isInteract = false;
            events = true;
            if (klueActive)
            {
                FindAnyObjectByType<clueButton>().klueBaru = true;
                FindAnyObjectByType<clueButton>().ShowKlue();
                klueActive = false;
            }
        }



    }
    void CountSentences()
    {
        for (int i = 0; i < playerSentences.Length; i++)
        {
            for (int j = 0; j < playerSentences[i].sentences.Length; j++)
            {
                countSentences++;
            }
        }
        for (int i = 0; i < npcSentences.Length; i++)
        {
            for (int j = 0; j < npcSentences[i].sentences.Length; j++)
            {
                countSentences++;
            }
        }
    }
    private IEnumerator StartDialogue()
    {

        playerMovementScript.interactNPC = true;

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
        if (audioPlayer != null)
        {
            audioPlayer.Play();
        }
        foreach (char letter in playerSentences[playerIndexI].sentences[playerIndexJ].ToCharArray())
        {
            playerDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        playerIndexJ++;
        if (playerIndexJ > playerSentences[playerIndexI].sentences.Length - 1)
        {
            nPCIndexI++;
            nPCIndexJ = 0;
        }
        playerContinueButton.SetActive(true);
        nextDialogue = true;
    }

    private IEnumerator TypeNPCDialogue()
    {
        if (audioNPC != null)
        {
            audioNPC.Play();
        }
        foreach (char letter in npcSentences[nPCIndexI].sentences[nPCIndexJ].ToCharArray())
        {
            nPCDialogueText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
        nPCIndexJ++;
        if (nPCIndexJ > npcSentences[nPCIndexI].sentences.Length - 1)
        {
            playerIndexI++;
            playerIndexJ = 0;
        }
        nPCContinueButton.SetActive(true);
        nextDialogue = true;
    }

    private IEnumerator ContinuePlayerDialogue()
    {
        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        playerDialogueText.text = "";

        playerSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        StartCoroutine(TypePlayerDialogue());
    }

    private IEnumerator ContinueNPCDialogue()
    {
        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        nPCDialogueText.text = "";

        nPCSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimationDelay);

        StartCoroutine(TypeNPCDialogue());
    }

    public void TriggerContinuePlayerDialogue()
    {
        nextDialogue = false;
        countClickButton++;
        Debug.Log("TriggerContinuePlayerDialog");

        /*   uIAudioSource.Play(); */

        nPCContinueButton.SetActive(false);


        if (playerIndexI > playerSentences.Length - 1)
        {
            Debug.Log("Player habis");
            nPCDialogueText.text = "";

            nPCSpeechBubbleAnimator.SetTrigger("Close");
        }
        if (playerIndexI <= playerSentences.Length - 1)
        {
            if (nPCIndexJ <= npcSentences[nPCIndexI].sentences.Length - 1)
            {
                nPCDialogueText.text = "";
                nPCSpeechBubbleAnimator.SetTrigger("Close");
                StartCoroutine(ContinueNPCDialogue());
            }
            else
            {
                playerDialogueText.text = "";
                nPCSpeechBubbleAnimator.SetTrigger("Close");
                StartCoroutine(ContinuePlayerDialogue());
            }

        }

    }

    public void TriggerContinueNPCDialogue()
    {
        nextDialogue = false;
        countClickButton++;
        Debug.Log("TriggerContinueNPCDialogu");

        /* uIAudioSource.Play(); */

        playerContinueButton.SetActive(false);

        if (nPCIndexI > npcSentences.Length - 1)
        {
            Debug.Log("NPC habis");
            playerDialogueText.text = "";

            playerSpeechBubbleAnimator.SetTrigger("Close");
            /* 
                        playerMovementScript.ToggleInteraction(); */
        }
        if (nPCIndexI <= npcSentences.Length - 1)
        {
            if (playerIndexJ <= playerSentences[playerIndexI].sentences.Length - 1)
            {
                playerDialogueText.text = "";
                playerSpeechBubbleAnimator.SetTrigger("Close");
                StartCoroutine(ContinuePlayerDialogue());
            }
            else
            {
                nPCDialogueText.text = "";
                playerSpeechBubbleAnimator.SetTrigger("Close");
                StartCoroutine(ContinueNPCDialogue());
            }

        }

    }


    void HideUI()
    {
        if (UIhide != null)
        {
            UIhide.SetActive(false);
        }

    }
    void UnHideUI()
    {
        if (UIhide != null)
        {

            UIhide.SetActive(true);

        }

    }

}