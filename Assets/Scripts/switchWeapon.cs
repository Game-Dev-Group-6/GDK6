using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchWeapon : MonoBehaviour
{
    battery battery;
    controlIntensityLighterWeapon controlIntensityLighterWeapon;
    controlIntesityLighter[] controlIntesity;
    int currentWeapon = 0;
    [SerializeField]
    GameObject[] weapon = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        controlIntensityLighterWeapon = GameObject.FindAnyObjectByType<controlIntensityLighterWeapon>();
        battery = GameObject.FindObjectOfType<battery>();

        for(int i = 0;i<weapon.Length;i++)
        {
            if (weapon[i] == weapon[0])
            {
                weapon[i].SetActive(true);
            }
            else
            {
                weapon[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }

        if(controlIntensityLighterWeapon != null)
        {
            if (battery.currentBattery <= 0)
            {
                battery.currentBattery = 1;
                SwitchWeapon();
            }
        }
    }
    void SwitchWeapon()
    {
        currentWeapon++;
        for (int i = 0; i < weapon.Length; i++)
        {
            if (weapon[i] == weapon[currentWeapon])
            {
                weapon[currentWeapon].SetActive(true);
            }
            else
            {
                weapon[i].SetActive(false);
            }

        }
        if (currentWeapon == weapon.Length - 1)
        {
            currentWeapon = -1;

        }
    }
}
