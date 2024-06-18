using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GundaAfterLose : MonoBehaviour
{

    //Atur Posisi Gunda

    //Atur posisi Trash
    [Header("Tentang Sampah")]
    [SerializeField] GameObject TrashInGunda;
    [SerializeField] GameObject TrashInGround, Trash;
    [SerializeField] bool throwTrash, trashFly;
    Vector3 newPos;
    [SerializeField] triggerCcollect TriggerCcollect;

    //END
    [Header("Tentang Event")]
    [SerializeField] DialogueManagerV2 dialogueManager1, dialogueManager2;
    [SerializeField] SpriteRenderer SpriteGunda;
    [SerializeField] ParticleSystem particleRespawn, particleBlink;
    [SerializeField] delayTime2 delayTime2;
    public bool playCondition;
    bool onePlayParticle, showGunda, startDialog1, oneTriggerDialog1, startDialog2, oneTriggerDialog2, gundaEnd, afterGundaEnd;

    //Transisi
    // Start is called before the first frame update
    void Start()
    {
        delayTime2 = GetComponent<delayTime2>();
        Trash.transform.position = TrashInGunda.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(GameObject.FindWithTag("Player").transform.position.x + 4f, transform.position.y);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playCondition = true;
        }
        if (playCondition)
        {
            ShowGunda();
        }
        if (throwTrash)
        {
            GundaThrowTrash();
        }
        if (Trash != null)
        {
            newPos = Vector3.MoveTowards(Trash.transform.position, TrashInGround.transform.position, 0.01f);
        }
        if (dialogueManager2.countClickButton == dialogueManager2.countSentences)
        {
            FindAnyObjectByType<movementController>().interactNPC = true;
            gundaEnd = true;
            GetComponent<SpriteRenderer>().enabled = false;
            particleBlink.Play();
            dialogueManager2.countClickButton = 0;
            afterGundaEnd = true;
        }
        if (afterGundaEnd)
        {
            if (delayTime2.Delay(6))
            {
                FindAnyObjectByType<movementController>().interactNPC = false;
                Destroy(gameObject);
            }
        }


    }
    void GundaThrowTrash()
    {
        if (!trashFly)
        {
            TriggerCcollect.trashCollected++;
            PlayerPrefs.SetInt("TrashCollected", TriggerCcollect.trashCollected);
            trashFly = true;
        }
        if (Trash != null)
        {
            Trash.transform.position = newPos;
            if (Trash.transform.position.x == TrashInGround.transform.position.x)
            {
                PlayerPrefs.SetString("DestroyTrashInPemakaman", "");
                //TriggerDialogue2
                if (!oneTriggerDialog2)
                {
                    dialogueManager2.TriggerStartDialogue();
                    oneTriggerDialog2 = true;
                }
            }
        }

    }
    void ShowGunda()
    {
        if (!onePlayParticle)
        {
            GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().flipX = false;
            FindAnyObjectByType<movementController>().interactNPC = true;
            particleRespawn.Play();
            onePlayParticle = true;
        }
        if (onePlayParticle && !gundaEnd)
        {
            if (!showGunda)
            {
                if (delayTime2.Delay(1.3f))
                {
                    showGunda = true;
                }
            }
            if (showGunda)
            {
                if (!SpriteGunda.enabled)
                {
                    SpriteGunda.enabled = true;
                }
                if (SpriteGunda.enabled)
                {
                    if (!startDialog1)
                    {
                        if (delayTime2.Delay(2))
                        {
                            startDialog1 = true;
                        }
                    }
                }
                if (startDialog1)
                {
                    //TriggerDialog
                    if (!oneTriggerDialog1)
                    {
                        if (dialogueManager1 != null)
                        {
                            dialogueManager1.TriggerStartDialogue();
                        }
                        oneTriggerDialog1 = true;
                    }
                    if (dialogueManager1.countClickButton == dialogueManager1.countSentences)
                    {
                        dialogueManager1.countClickButton = 0;
                        FindAnyObjectByType<movementController>().interactNPC = true;
                        PlayerPrefs.SetString("ShowTrashInPemakaman", "");
                        throwTrash = true;
                    }
                }
            }
        }
    }
}
