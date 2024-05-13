using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class controlIntesity : MonoBehaviour
{
    
    delayTime delayTime;
    [SerializeField]
    float timeDelayChangeIntensity;
    [SerializeField]
    float intenMin,intenMax;
    Light2D lightInten;
    

    void Start()
    {
        lightInten = GetComponent<Light2D>();
        delayTime =  GetComponent<delayTime>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lightInten != null)
        {
            if (delayTime.Delay(timeDelayChangeIntensity))
            {
                        lightInten.intensity = Random.Range(intenMin, intenMax);
            }
        }
    }
    
}
