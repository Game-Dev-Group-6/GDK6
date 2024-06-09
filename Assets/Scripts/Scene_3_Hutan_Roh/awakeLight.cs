using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class awakeLight : MonoBehaviour
{
    public float[] intensitys;
    Light2D[] lights;
    // Start is called before the first frame update
    void Awake()
    {
        lights = GameObject.FindObjectsOfType<Light2D>();
        intensitys = new float[lights.Length];
        GetIntensity();
    }
    void Start()
    {
        LightFirst();
    }

    // Update is called once per frame
    void Update()
    {
        OnAllLight();
    }
    void GetIntensity()
    {
        int i = 0;
        foreach (Light2D light in lights)
        {
            intensitys[i] = light.intensity;
            i++;
        }
    }
    void LightFirst()
    {
        foreach (Light2D light in lights)
        {
            light.intensity = 0;
        }
    }

    void OnAllLight()
    {
        int i = 0;
        foreach (Light2D light in lights)
        {
            if (light.intensity < intensitys[i])
            {
                light.intensity += 0.05f;
            }
            i++;
        }
    }
}
