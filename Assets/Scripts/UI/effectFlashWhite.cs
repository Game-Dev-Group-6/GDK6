using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;

using UnityEngine;

public class effectFlashWhite : MonoBehaviour
{
    [SerializeField] bool forGetFlashlightYellow;
    [SerializeField] GameObject trigger;
    public enum listGetTrriggerFrom
    {
        Dialogue_Manager_V2
    }
    public listGetTrriggerFrom ListGetTrriggerFrom;
    [SerializeField] public bool events = false;
    bool reverse = false;
    [SerializeField][Range(0f, 1f)] float intensityFlash;
    [SerializeField][Range(0f, 1f)] float intensityFlash1;
    Color newColor, newColor1;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        newColor = sprite.color;
        newColor1 = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        TriggerEvents();
        newColor.a = intensityFlash;
        newColor1.a = intensityFlash1;
        sprite.color = newColor;
        image.GetComponent<UnityEngine.UI.Image>().color = newColor1;
        ListTrigger();
    }

    void TriggerEvents()
    {
        if (events && !reverse)
        {
            image.SetActive(true);
            if (intensityFlash <= 1)
            {
                intensityFlash += 0.01f;
            }
            if (intensityFlash1 <= 1)
            {
                intensityFlash1 += 0.005f;
            }
            if (intensityFlash1 > 1)
            {
                reverse = true;
                if (forGetFlashlightYellow)
                {
                    PlayerPrefs.SetString("HaveFlashlightYellow", "");
                }
            }
        }

        else if (events && reverse)
        {

            if (intensityFlash1 >= 0)
            {
                intensityFlash1 -= 0.01f;
            }
            if (intensityFlash >= 0)
            {
                intensityFlash -= 0.005f;
            }
            if (intensityFlash < 0)
            {
                reverse = false;
                events = false;
                image.SetActive(false);
            }
        }
    }

    void ListTrigger()
    {
        switch (ListGetTrriggerFrom)
        {
            case listGetTrriggerFrom.Dialogue_Manager_V2:
                if (trigger != null)
                {
                    DialogueManagerV2 dialogueManagerV2 = trigger.GetComponent<DialogueManagerV2>();
                    if (dialogueManagerV2.countClickButton == dialogueManagerV2.countSentences)
                    {
                        events = true;
                        dialogueManagerV2.countClickButton = 0;
                    }
                }
                break;
        }
    }
}
