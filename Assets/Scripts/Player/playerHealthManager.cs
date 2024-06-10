using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerHealthManager : MonoBehaviour
{
    //Make PlayerPrefs "CurrentHealth"
    [SerializeField] float currentHealt;
    [SerializeField] Slider slider;
    [SerializeField] Text text;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("CurrentHealth"))
        {
            PlayerPrefs.SetFloat("CurrentHealth", 100);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentHealth"))
        {
            currentHealt = PlayerPrefs.GetFloat("CurrentHealth");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            TakeDamage(1);
        }
        if (slider != null)
        {
            slider.value = (float)currentHealt / 100;
            PlayerPrefs.SetFloat("CurrentHealth", currentHealt);
        }
        if (text != null)
        {
            text.text = (int)currentHealt + "/100";
        }

    }

    public void TakeDamage(float Damage)
    {
        currentHealt -= Damage;
    }

}
