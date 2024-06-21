using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuntaAfterDialogue : MonoBehaviour
{
    [SerializeField] DialogueManagerV2 dialogueManagerV2;
    public bool kuntaHide;
    Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        newColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManagerV2.countClickButton == dialogueManagerV2.countSentences)
        {
            kuntaHide = true;
            dialogueManagerV2.countClickButton = 0;
        }
        MakeInvisible();
    }
    void MakeInvisible()
    {
        if (kuntaHide)
        {
            if (newColor.a > 0)
            {
                newColor.a -= 0.001f;
                GetComponent<SpriteRenderer>().color = newColor;
                if (newColor.a <= 0)
                {
                    kuntaHide = false;
                }
            }
        }
    }
}
