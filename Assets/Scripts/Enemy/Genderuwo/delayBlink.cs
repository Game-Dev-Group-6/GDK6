using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class delayBlink : MonoBehaviour
{
    public float Timer;
    public float currentTime;
    public float lastTime;


    // Update is called once per frame
    void Update()
    {

    }

    public bool Delay(float timeDelay)
    {
        currentTime = Time.deltaTime;
        Timer += Time.deltaTime;
        if (Timer > timeDelay)
        {
            Timer = 0;
            return true;
        }
        return false;

    }
}
