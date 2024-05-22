using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class controlIntensityLighterWeapon : MonoBehaviour
{

    [SerializeField][Range(0f, 10f)] float bateraiTambah, bateraiKurang;
    [SerializeField] GameObject weapon;
    [SerializeField] float timeDelayChangeIntensity;
    [SerializeField] float intenMin, intenMax;
    bool reverseInten = false;
    Light2D lightInten;
    battery battery;
    delayTime2 delayTime;


    void Start()
    {
        lightInten = weapon.GetComponent<Light2D>();
        delayTime = GetComponent<delayTime2>();
        battery = GetComponent<battery>();
    }

    // Update is called once per frame
    void Update()
    {
        BatteryManager();
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
    void BatteryManager()
    {
        if (lightInten != null)
        {
            if (delayTime.Delay(timeDelayChangeIntensity))
            {
                reverseInten = true;
                if (weapon.activeSelf)
                {
                    if (battery.currentBattery > 0 && battery.currentBattery <= 100)
                    {
                        battery.currentBattery -= bateraiKurang;
                    }
                }
                else if (!weapon.activeSelf)
                {
                    if (battery.currentBattery < battery.maxBattery)
                    {
                        battery.currentBattery += bateraiTambah;
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


}
