using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayHurt : MonoBehaviour
{
    public float Timer;

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
