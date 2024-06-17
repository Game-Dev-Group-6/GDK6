using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class playerHealthManager : MonoBehaviour
{
    public enum Enemy
    {
        Pocica, Gunda
    }
    public Enemy enemy;
    [SerializeField] ParticleSystem particleSystemDeath;
    //Make PlayerPrefs "CurrentHealth"
    [SerializeField] float currentHealt;
    [SerializeField] Slider slider;
    [SerializeField] Text text;
    [SerializeField] bool respawnPlayerInHutanRoh, respawnPlayerInPemakaman;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("CurrentHealth"))
        {
            PlayerPrefs.SetFloat("CurrentHealth", 100);
            if (respawnPlayerInHutanRoh)
            {
                PlayerPrefs.SetString("TriggerJumpScare", "");
                PlayerPrefs.SetString("HaveFlashlightWhite", "");
            }
            if (respawnPlayerInPemakaman)
            {
                PlayerPrefs.SetString("HaveFlashlightWhite", "");
            }
        }
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
        ConditionPlayerDeath();
    }

    public void TakeDamage(float Damage)
    {
        currentHealt -= Damage;
    }

    [SerializeField] GameObject FlashlightInPlayer;
    void ConditionPlayerDeath()
    {
        if (currentHealt < 1)
        {
            if (particleSystemDeath != null)
            {
                if (GetComponent<SpriteRenderer>().enabled)
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                    particleSystemDeath.Play();
                    GetComponent<movementController>().enabled = false;
                    PlayerPrefs.DeleteKey("HaveFlashlightWhite");
                    if (FlashlightInPlayer != null)
                    {
                        FlashlightInPlayer.SetActive(false);
                    }
                }
            }
            if (!GetComponent<SpriteRenderer>().enabled)
            {

                if (GetComponent<delayTime2>().Delay(4.5f))
                {
                    PlayerPrefs.DeleteKey("CurrentHealth");
                    PickScene();
                }
            }
        }
    }

    void PickScene()
    {
        switch (enemy)
        {
            case Enemy.Pocica:
                SceneManager.LoadScene(5);
                break;
            case Enemy.Gunda:
                SceneManager.LoadScene(15);
                break;
        }
    }
}
