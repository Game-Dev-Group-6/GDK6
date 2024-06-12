using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class kuntaAfterPocica : MonoBehaviour
{
    [SerializeField] DialogueManagerV2 dialogueManagerV2;
    Color newColor;
    [SerializeField] public bool makeVisible;
    bool reverse, triggerDialogue, makeInvisible, firstDialogue;
    void Awake()
    {
        newColor = GetComponent<SpriteRenderer>().color;
        newColor.a = 0;
        GetComponent<SpriteRenderer>().color = newColor;
    }
    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        StartDialogue();
        MakeInvisible();
        MakeVisible();

    }
    void StartDialogue()
    {
        if (triggerDialogue)
        {
            dialogueManagerV2.TriggerStartDialogue();
            triggerDialogue = false;
        }
    }
    void MakeInvisible()
    {
        if (dialogueManagerV2.countClickButton == dialogueManagerV2.countSentences)
        {
            FindAnyObjectByType<movementController>().interactNPC = false;
            makeInvisible = true;
            dialogueManagerV2.countClickButton = 0;
        }
    }

    void MakeVisible()
    {
        if (newColor.a <= 1 && !reverse && makeVisible)
        {
            if (!firstDialogue)
            {
                triggerDialogue = true;
                firstDialogue = true;
            }
            newColor.a += 0.005f;
            if (newColor.a > 1)
            {
                reverse = true;
            }
        }
        if (newColor.a > 0 && reverse && makeInvisible)
        {
            newColor.a -= 0.005f;
            if (newColor.a < 0)
            {

            }
        }
        GetComponent<SpriteRenderer>().color = newColor;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!PlayerPrefs.HasKey("Kunta2"))
            {
                makeVisible = true;
            }
        }
    }
}