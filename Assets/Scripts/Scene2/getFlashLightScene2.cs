using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFlashLightScene2 : MonoBehaviour
{
    GameObject flashLight;
    // Start is called before the first frame update
    void Start()
    {
        flashLight = transform.GetChild(0).gameObject;
        if (PlayerPrefs.HasKey("GetFlashLight"))
        {
            flashLight.SetActive(PlayerPrefs.GetInt("GetFlashLight", 0) == 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
