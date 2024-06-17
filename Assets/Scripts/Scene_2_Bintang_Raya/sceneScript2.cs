using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneScript2 : MonoBehaviour
{
    GameObject player;
    delayTime2 delayTime2;
    [SerializeField] DialogueManagerV2[] monologTriggers;
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
        Script1();
        DeleteSceneScript();
    }
    void Script1()
    {
        if (PlayerPrefs.HasKey("SceneScript"))
        {
            if (PlayerPrefs.GetInt("SceneScript") == 0)
            {

                if (delayTime2.Delay(0.5f))
                {
                    monologTriggers[0].TriggerStartDialogue();
                    PlayerPrefs.SetInt("SceneScript", 1);
                }

            }
        }
    }

    public void Script2()
    {
        if (PlayerPrefs.HasKey("SceneScript"))
        {
            if (PlayerPrefs.GetInt("SceneScript", 0) == 1)
            {

                Debug.Log("Aktif Script2");
                if (delayTime2.Delay(0.5f))
                {
                    monologTriggers[1].TriggerStartDialogue();
                    PlayerPrefs.SetInt("SceneScript", 1);
                }
            }
        }
    }

    void DeleteSceneScript()
    {
        if (PlayerPrefs.HasKey("HaveFlashlightWhite"))
        {
            PlayerPrefs.DeleteKey("SceneScript");
            PlayerPrefs.SetString("CanEnter", "");
        }
    }
}
