using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayFlashLight_1 : MonoBehaviour
{
    [SerializeField] float Timer;
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
