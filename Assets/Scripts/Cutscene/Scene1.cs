using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Scene1 : MonoBehaviour
{
    [SerializeField] GameObject canvasTransition, getItemCanvas;
    [SerializeField] PlayableDirector playableDirector1, playableDirector2;
    [SerializeField] GameObject transition;
    [SerializeField] AudioSource audioSource;
    bool gamePlay = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("Scene1_Timeline"))
        {
            Debug.Log("Detect Timeline");
            if (PlayerPrefs.GetInt("Scene1_Timeline") == 1)
            {
                Debug.Log("Load Timeline 1");
                playableDirector1.Play();
                PlayerPrefs.SetInt("Scene1_Timeline", 2);
                gamePlay = true;
            }
            else if (PlayerPrefs.GetInt("Scene1_Timeline") == 2)
            {
                Debug.Log("Load Timeline 2");
                playableDirector2.Play();
                gamePlay = true;
                PlayerPrefs.SetInt("Scene1_Timeline", 3);

            }
        }
        if (PlayerPrefs.HasKey("GamePlay"))
        {
            transition.GetComponent<transition>().enabled = true;
        }

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (gamePlay == true)
        {
            ControlVolume();
        }
        ControlTransition();
    }
    void ControlVolume()
    {
        if (audioSource.GetComponent<AudioSource>().spatialBlend > 0)
        {
            audioSource.GetComponent<AudioSource>().spatialBlend -= 0.0005f;
        }
    }

    void ControlTransition()
    {
        if (getItemCanvas.activeSelf)
        {
            canvasTransition.SetActive(false);
        }
        else if (!getItemCanvas.activeSelf)
        {
            canvasTransition.SetActive(true);
        }
    }
}
