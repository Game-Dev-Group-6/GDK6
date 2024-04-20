using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class controlIntesityLighter : MonoBehaviour
{

    delayTime delayTime;
    [SerializeField]
    float timeDelayChangeIntensity;
    [SerializeField]
    float intenMin, intenMax;
    Light2D lightInten;
 
    bool reverseInten = false;

    void Start()
    {
        lightInten = GetComponent<Light2D>();
        delayTime = GetComponent<delayTime>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightInten != null)
        {
            if (delayTime.Delay(timeDelayChangeIntensity))
            {
                reverseInten = true;
            }
        }
        if (reverseInten)
        {
            IntensityLighter();
        }

    }
    void IntensityLighter()
    {
        lightInten.intensity -= 0.05f;
        if(lightInten.intensity < intenMin)
        {
            for(float i = lightInten.intensity;i<=intenMax;i += 0.05f)
            {
                lightInten.intensity += 0.05f;
                if(lightInten.intensity >= intenMax)
                {
                    reverseInten = false;
                }
            }
        }
    }


}
