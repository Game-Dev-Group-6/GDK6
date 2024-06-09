using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class uiFlashlightYellow : MonoBehaviour
{
    [SerializeField] DialogueTrigger dialogueTrigger;
    [SerializeField] getFlashLight getFlashLight;
    [SerializeField] effectFlashWhite effectFlashWhite;
    bool TriggerDialogue2, triggerCanvas;
    delayTime2 delayTime2;
    // Start is called before the first frame update
    void Start()
    {
        delayTime2 = GetComponent<delayTime2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (effectFlashWhite.events)
        {
            triggerCanvas = true;
        }
        if (triggerCanvas)
        {
            ShowCanvas();
        }
        if (TriggerDialogue2)
        {
            if (delayTime2.Delay(0.5f))
            {
                dialogueTrigger.OtherTrigger();
                TriggerDialogue2 = false;
            }
        }

    }

    void ShowCanvas()
    {
        if (delayTime2.Delay(3f))
        {
            getFlashLight.canvasActive = true;
            triggerCanvas = false;
        }
    }

    public void buttonAmbil()
    {
        getFlashLight.canvasActive = false;
        TriggerDialogue2 = true;
        triggerCanvas = false;
    }
}
