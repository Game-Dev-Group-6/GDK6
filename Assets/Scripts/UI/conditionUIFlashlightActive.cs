using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conditionUIFlashlightActive : MonoBehaviour
{
    bool uiActive = false;
    [SerializeField] GameObject UIFlashlight;
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
        if (PlayerPrefs.HasKey("HaveFlashlightWhite"))
        {
            UIFlashlight.SetActive(true);
        }
        if (!PlayerPrefs.HasKey("HaveFlashlightWhite"))
        {
            UIFlashlight.SetActive(false);
        }
    }
}
