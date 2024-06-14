using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clueButton : MonoBehaviour
{
    movementController movementController;
    public enum ListKlue
    {
        Klue1, Klue2, Klue3, Klue4, Klue5, Klue6, Klue7, Klue8
    }
    public ListKlue listKlue;
    [SerializeField] GameObject cluePaper, Panel;
    [SerializeField] public bool klueBaru;
    bool reverse, startReverse;
    delayTime2 delayTime2;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        delayTime2 = GetComponent<delayTime2>();
        movementController = FindAnyObjectByType<movementController>();
    }

    // Update is called once per frame
    void Update()
    {
        NotifKlue();
    }
    void NotifKlue()
    {
        if (klueBaru)
        {
            if (slider.value < 1 && !reverse)
            {
                slider.value += 0.01f;
                if (slider.value >= 1)
                {
                    startReverse = true;
                }
            }
            if (slider.value > 0 && reverse)
            {
                slider.value -= 0.01f;
                if (slider.value <= 0)
                {
                    klueBaru = false;
                    reverse = false;
                }

            }
        }
        if (startReverse)
        {
            if (delayTime2.Delay(1))
            {
                reverse = true;
                delayTime2.Timer = 0;
                startReverse = false;
            }
        }
        if (cluePaper.activeSelf)
        {
            if (movementController != null)
            {
                movementController.interactNPC = true;
            }

        }
    }
    public void InteractButtonOpen()
    {
        Panel.SetActive(true);
        cluePaper.SetActive(true);
    }
    public void InteractButtonClosed()
    {
        Panel.SetActive(false);
        cluePaper.SetActive(false);
        movementController.interactNPC = false;
    }

    public void ShowKlue()
    {
        switch (listKlue)
        {
            case ListKlue.Klue1:
                PlayerPrefs.SetString("Klue1", "");
                break;
            case ListKlue.Klue2:
                PlayerPrefs.SetString("Klue2", "");
                break;
            case ListKlue.Klue3:
                PlayerPrefs.SetString("Klue3", "");
                break;
            case ListKlue.Klue4:
                PlayerPrefs.SetString("Klue4", "");
                break;
            case ListKlue.Klue5:
                PlayerPrefs.SetString("Klue5", "");
                break;
            case ListKlue.Klue6:
                PlayerPrefs.SetString("Klue6", "");
                break;
            case ListKlue.Klue7:
                PlayerPrefs.SetString("Klue7", "");
                break;
            case ListKlue.Klue8:
                PlayerPrefs.SetString("Klue8", "");
                break;
        }
    }
    /*
    -Button akan berubah warna ketika ada klue yang aktif (menggunakan PlayerPrefs("ButtonActive"),
        PlayerPrefs akan terus ada ketika player tidak mengeklik button)
    -Ketika klue aktif dan player tidak melakukan klik pada button maka warna akan terus berubah
    -Ketika player melakukan klik maka warna akan kembali normal
    */
}
