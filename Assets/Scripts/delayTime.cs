using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayTime : MonoBehaviour
{
    [SerializeField]
    float currentTime,lastTime;

    public bool Delay(float delay)
    {
        currentTime = Time.time - lastTime;

        if(currentTime > delay){
            lastTime = Time.time;
            return true;
        }else return false;
    }
}
