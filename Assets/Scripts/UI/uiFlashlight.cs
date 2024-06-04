using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiFlashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlightYellow, flashlightWhite;
    [SerializeField] GameObject iconFlashlightYellow, iconFlashlightWhite, iconBattery;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIconFlashlight();
    }
    void ChangeIconFlashlight()
    {
        if (flashlightWhite != null)
        {
            if (flashlightWhite.activeSelf)
            {
                Debug.Log("WhiteActive");
                iconFlashlightWhite.SetActive(true);
                iconFlashlightYellow.SetActive(false);
                iconBattery.SetActive(false);
            }
            if (flashlightYellow != null)
            {
                if (flashlightYellow.activeSelf)
                {
                    Debug.Log("YellowActive");
                    iconFlashlightYellow.SetActive(true);
                    iconBattery.SetActive(true);
                    iconFlashlightWhite.SetActive(false);
                }
            }

        }

    }
}
