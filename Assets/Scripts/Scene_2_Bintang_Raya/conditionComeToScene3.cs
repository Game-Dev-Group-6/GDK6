using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conditionComeToScene3 : MonoBehaviour
{
    bool firstInteract = false;
    bool isGetFlashlight = false;
    [SerializeField] DialogueManager[] dialogueManagers;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MonologTrigger();
    }
    void ConditionGetFlashLight()
    {
        if (PlayerPrefs.HasKey("GetFlashLight"))
        {
            if (PlayerPrefs.GetInt("GetFlashLight", 0) == 1)
            {
                Debug.Log("Menuju Scene3");
                /* dialogueManagers[1].TriggerStartDialogue(); */
                transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (PlayerPrefs.GetInt("GetFlashLight", 0) == 0)
            {
               /*  dialogueManagers[0].TriggerStartDialogue(); */
                transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            }
        }

    }
    void MonologTrigger()
    {
        if (transform.position.x < GameObject.FindWithTag("Player").transform.position.x)
        {
            if (!firstInteract)
            {
                ConditionGetFlashLight();
                firstInteract = true;
            }
        }
    }
}
