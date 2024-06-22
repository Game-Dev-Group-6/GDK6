using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class treeDurability : MonoBehaviour
{
    [SerializeField] GameObject canvas, durabilityBar, button;
    [SerializeField] public int timeForBreakTree;
    [SerializeField] Slider sliderDurabity;
    [SerializeField] Text waiting;
    int waitingTime;
    [SerializeField] int maxDurability;
    public int currentDurability;
    public bool durabilityActive = false;
    [SerializeField] GameObject[] treeCut;

    delayTime2 delayTime2;
    void Start()
    {
        delayTime2 = GetComponent<delayTime2>();
        currentDurability = maxDurability;
        waitingTime = timeForBreakTree;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTreeCutActive();
        ShowSlider();
        if (currentDurability <= 0)
        {
            Debug.Log("DESTROY");
        }

    }
    void CheckTreeCutActive()
    {
        foreach (GameObject tree in treeCut)
        {
            if (tree.activeSelf && durabilityActive)
            {
                canvas.SetActive(true);
                WaitingTime();
                durabilityBar.transform.position = tree.transform.GetChild(1).transform.position;
                button.transform.position = tree.transform.GetChild(0).transform.position;
            }
        }
    }
    void WaitingTime()
    {
        if (waitingTime > 0)
        {
            if (delayTime2.Delay(1))
            {
                waitingTime--;
            }
        }
    }

    public void CanBreak()
    {
        if (waitingTime <= 0)
        {
            //Button Break Active
            waitingTime = timeForBreakTree;
            TreeDurability();
        }
    }

    void TreeDurability()
    {
        currentDurability--;
    }


    void ShowSlider()
    {
        sliderDurabity.value = (float)currentDurability / maxDurability;
        if (waitingTime > 0)
        {
            waiting.text = waitingTime + "s";
        }
        else if (waitingTime <= 0)
        {
            waiting.text = "Click";
        }

        /* sliderWaitingTime.value = (float)waitingTime / timeForBreakTree; */
    }
}
