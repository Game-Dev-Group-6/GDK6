using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class controlIntensityLighterWeapon : MonoBehaviour
{
    battery battery;
    [SerializeField]
    GameObject weapon;
    delayTime delayTime;
    [SerializeField]
    float timeDelayChangeIntensity;
    [SerializeField]
    float intenMin, intenMax;
    Light2D lightInten;

    bool reverseInten = false;

    void Start()
    {
        lightInten = weapon.GetComponent<Light2D>();
        delayTime = GetComponent<delayTime>();
        battery = GetComponent<battery>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightInten != null)
        {
            if (delayTime.Delay(timeDelayChangeIntensity))
            {
                reverseInten = true;
                if(weapon.activeSelf)
                {
                    battery.currentBattery--;
                }else if (!weapon.activeSelf)
                {
                    if(battery.currentBattery < battery.maxBattery)
                    {
                        battery.currentBattery += 0.5f;
                        Debug.Log("kurang");
                    }
                    
                }
                
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
        if (lightInten.intensity < intenMin)
        {
            for (float i = lightInten.intensity; i <= intenMax; i += 0.05f)
            {
                lightInten.intensity += 0.05f;
                if (lightInten.intensity >= intenMax)
                {
                    reverseInten = false;
                }
            }
        }
    }
}
