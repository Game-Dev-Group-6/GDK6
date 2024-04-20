using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battery : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    public float maxBattery;
    [SerializeField]
    public float currentBattery;
    // Start is called before the first frame update
    void Start()
    {
        maxBattery = 100;
        currentBattery = maxBattery;

    }

    // Update is called once per frame
    void Update()
    {

        //mekanik battery ada pada script controlInstensityLighter

        slider.value = (float)currentBattery / maxBattery;
    }
}
