using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class controlIntesity : MonoBehaviour
{


    [SerializeField] float timeDelayChangeIntensity;
    [SerializeField] float intenMin, intenMax;
    Light2D lightInten;
    delayTime2 delayTime2;


    void Start()
    {
        lightInten = GetComponent<Light2D>();
        delayTime2 = GetComponent<delayTime2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightInten != null)
        {
            if (delayTime2.Delay(timeDelayChangeIntensity))
            {
                lightInten.intensity = Random.Range(intenMin, intenMax);
            }
        }
    }

}
