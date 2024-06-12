using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conditionUIFlashlightActive : MonoBehaviour
{
    [SerializeField] GameObject UIFlashlight, UIHealth, UITrash;
    // Start is called before the first frame update
    private void Awake()
    {
        /*  if()   PlayerPrefs.HasKey("HaveFlashlightWhite") ? uiActive = false : uiActive = true; */
    }
    // Update is called once per frame
    void Update()
    {
        ConditionUIActive();
    }
    void ConditionUIActive()
    {
        if (!PlayerPrefs.HasKey("CutScene"))
        {
            if (PlayerPrefs.HasKey("HaveFlashlightWhite"))
            {
                UIFlashlight.SetActive(true);
            }
            if (!PlayerPrefs.HasKey("HaveFlashlightWhite"))
            {
                UIFlashlight.SetActive(false);
            }
            UIHealth.SetActive(true);
            UITrash.SetActive(true);
        }
        if (PlayerPrefs.HasKey("CutScene"))
        {
            UIFlashlight.SetActive(false);
            UIHealth.SetActive(false);
            UITrash.SetActive(false);
        }


    }
}
