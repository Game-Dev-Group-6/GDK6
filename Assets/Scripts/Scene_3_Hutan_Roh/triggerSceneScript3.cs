using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class triggerSceneScript3 : MonoBehaviour
{

    [SerializeField] GameObject ColliderPenghalang;
    [SerializeField] sceneScript3 sceneScript3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("HaveFlashlightWhite"))
        {
            if (ColliderPenghalang != null)
            {
                Destroy(ColliderPenghalang);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !PlayerPrefs.HasKey("HaveFlashlightWhite"))
        {
            if (!PlayerPrefs.HasKey("SceneScript3"))
            {
                sceneScript3.Script1();
            }
            if (PlayerPrefs.GetInt("SceneScript3") == 0 && !PlayerPrefs.HasKey("HaveFlashlightWhite"))
            {
                sceneScript3.Script2();
            }

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!PlayerPrefs.HasKey("SceneScript3"))
            {
                sceneScript3.Script1();
            }
            if (PlayerPrefs.GetInt("SceneScript3") == 0 && !PlayerPrefs.HasKey("HaveFlashlightWhite"))
            {
                sceneScript3.Script2();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (PlayerPrefs.HasKey("SceneScript3"))
            {
                if (PlayerPrefs.GetInt("SceneScript3") == 1)
                {
                    PlayerPrefs.SetInt("SceneScript3", 0);
                }
            }
        }
    }
}
