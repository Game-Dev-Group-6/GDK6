using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class controlIntesityLighter : MonoBehaviour
{
    bool MulaiKedip = true;
    [SerializeField] int random;
    float intenMin = 0, intenMax;
    bool reverseInten = false;
    Light2D lightInten;
    delayTime2 delayTime;
    delayFlashLight_1 delayFlashLight_1;


    void Start()
    {
        lightInten = GetComponent<Light2D>();
        delayTime = GetComponent<delayTime2>();
        delayFlashLight_1 = GetComponent<delayFlashLight_1>();
        intenMax = lightInten.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        RandomInt();
        BanyakKedip();
    }
    void RandomInt()
    {
        if (delayFlashLight_1.Delay(7) && MulaiKedip)
        {
            random = Random.Range(1, 4);
        }
    }

    void BanyakKedip()
    {
        if (random > 0)
        {
            MulaiKedip = false;
            IntensityLighter();
        }
        else if (random <= 0)
        {
            MulaiKedip = true;
        }
    }

    void IntensityLighter()
    {
        if (!reverseInten)
        {
            lightInten.intensity -= 0.5f;
            if (lightInten.intensity <= intenMin)
            {
                reverseInten = true;
            }
        }
        if (delayTime.Delay(1))
        {
            Debug.Log("+");
        }
        if (reverseInten)
        {

            lightInten.intensity += 0.5f;
            if (lightInten.intensity >= intenMax)
            {
                reverseInten = false;
                random--;
            }
        }
    }


}
