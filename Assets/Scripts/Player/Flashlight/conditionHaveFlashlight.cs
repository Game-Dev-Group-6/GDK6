using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conditionHaveFlashlight : MonoBehaviour
{
    //Script ini untuk menentukan apakah player mempunyai Flashlight atau tidak, lebih tepatnya untuk menampilkan flashlight
    [SerializeField] GameObject flashlight;
    [SerializeField] switchWeapon switchWeapon;
    public bool flashlightWhite = false;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        ConditonFlashlight();
    }

    // Update is called once per frame
    void Update()
    {
        ConditonFlashlight();
        if (flashlightWhite)
        {
            PlayerPrefs.SetString("HaveFlashlightWhite", "flashlightWhite");
            flashlight.SetActive(true);
            flashlightWhite = false;
        }
    }
    public void ConditonFlashlight()//Pertama akan mendapatkan flashlightWhite dengan mengaktifkan lagsung object, kedua mendapatkan flashlightYellow dengan mengaktifkan SwitchWeapon
    {
        if (!PlayerPrefs.HasKey("HaveFlashlightWhite"))
        {
            flashlight.SetActive(false);

        }
        if (PlayerPrefs.HasKey("HaveFlashlightWhite"))
        {
            flashlight.SetActive(true);
            if (PlayerPrefs.HasKey("HaveFlashlightYellow"))
            {
                switchWeapon.enabled = true;
            }
        }
    }
}
