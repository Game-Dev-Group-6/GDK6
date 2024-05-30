using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{
    public enum SelectSceneTransition
    {
        SCENE_2_AND_3,
        SCENE_3_AND_4,
        SCENE_4_AND_5,
        SCENE_5_AND_6,
        SCENE_6_AND_7
    }
    public SelectSceneTransition selectSceneTransition;
    [SerializeField] bool goSceneTransition = false;
    public enum SelectScene
    {
        PREVIOUS_SCENE,
        NEXT_SCENE
    }
    public SelectScene selectScene;
    [SerializeField] PlayerPrefsSave playerPrefsSave;
    [Range(-5, 5)][SerializeField] float giveDistance;
    GameObject player;

    bool nextScene = true;
    bool Trigger = false;
    [SerializeField] int LoadScene;
    delayTime2 delayTime2;
    Light2D[] lights;


    void Awake()
    {
        delayTime2 = GetComponent<delayTime2>();
        lights = GameObject.FindObjectsOfType<Light2D>();
        player = GameObject.FindWithTag("Player");
        ChooseScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger)
        {
            if (goSceneTransition)
            {
                ChooseSceneTransition();
            }
            if (playerPrefsSave != null)
            {
                playerPrefsSave.SetPosPlayer(giveDistance);
            }
            PlayerPrefs.SetInt("flipX", player.GetComponent<SpriteRenderer>().flipX ? 1 : 0);
            player.GetComponent<movementController>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            Debug.Log("Trigger");
            OffAllLight();
            if (delayTime2.Delay(5))
            {
                SceneManager.LoadScene(LoadScene);
            }
        }
    }
    void OffAllLight()
    {
        foreach (Light2D light in lights)
        {
            if (light.intensity > 0)
            {
                light.intensity -= 0.2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Trigger = true;
        }
    }

    void ChooseScene()
    {
        switch (selectScene)
        {
            case SelectScene.PREVIOUS_SCENE:
                nextScene = false;
                break;
            case SelectScene.NEXT_SCENE:
                nextScene = true;
                break;
        }
    }

    void ChooseSceneTransition()
    {
        switch (selectSceneTransition)
        {
            case SelectSceneTransition.SCENE_2_AND_3:
                PlayerPrefs.SetInt("Scene2To3", nextScene ? 1 : 0);
                break;
            case SelectSceneTransition.SCENE_3_AND_4:
                PlayerPrefs.SetInt("Scene3To4", nextScene ? 1 : 0);
                break;
            case SelectSceneTransition.SCENE_4_AND_5:
                PlayerPrefs.SetInt("Scene4To5", nextScene ? 1 : 0);
                break;
            case SelectSceneTransition.SCENE_5_AND_6:
                PlayerPrefs.SetInt("Scene5To6", nextScene ? 1 : 0);
                break;
            case SelectSceneTransition.SCENE_6_AND_7:
                PlayerPrefs.SetInt("Scene6To7", nextScene ? 1 : 0);
                break;
        }
    }
}
