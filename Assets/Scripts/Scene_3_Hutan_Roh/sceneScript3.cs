using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneScript3 : MonoBehaviour
{
    GameObject player;
    delayTime2 delayTime2;
    [SerializeField] monologTrigger[] monologTriggers;
    void Awake()
    {
        delayTime2 = GetComponent<delayTime2>();
        player = GameObject.FindWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Script1()
    {
        if (!PlayerPrefs.HasKey("SceneScript3"))
        {
            if (delayTime2.Delay(0.5f))
            {
                monologTriggers[0].MonologTrigger();
                PlayerPrefs.SetInt("SceneScript3", 0);
                PlayerPrefs.SetInt("CanEnter", 0);
                PlayerPrefs.SetInt("CanGetFlashlightInTent", 0);
            }
        }
    }
    public void Script2()
    {
        if (PlayerPrefs.HasKey("SceneScript3"))
        {
            if (PlayerPrefs.GetInt("SceneScript3") == 0)
            {
                if (delayTime2.Delay(0.5f))
                {
                    monologTriggers[1].MonologTrigger();
                    PlayerPrefs.SetInt("SceneScript3", 1);
                }
            }
        }
    }
}
