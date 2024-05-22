using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class delayTime2 : MonoBehaviour
{
    public float Timer;


    // Update is called once per frame
    void Update()
    {

    }

    public bool Delay(float timeDelay)
    {
        Timer += Time.deltaTime;
        if (Timer > timeDelay)
        {
            Timer = 0;
            return true;
        }
        return false;

    }
}
