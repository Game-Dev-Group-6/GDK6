using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamelan : MonoBehaviour
{
    static bool isGetFlashlight = false;
    [SerializeField] AudioClip[] GamelanWhisper;
    public static int indexAudio = 0;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("GamelanWhisperPlay"))
        {
            indexAudio = PlayerPrefs.GetInt("GamelanWhisperPlay");
        }
        if (PlayerPrefs.HasKey("CanGetFlashlightInTent"))
        {
            isGetFlashlight = true;
        }
        ConditionGamelanWhisperPlay();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    void ConditionGamelanWhisperPlay()
    {
        if (indexAudio == 0)
        {
            audioSource.clip = GamelanWhisper[0];
            audioSource.Play();
        }
        else if (indexAudio == 1)
        {
            audioSource.clip = GamelanWhisper[1];
            audioSource.Play();
        }
    }
    public static void GamelanStop()
    {
        if (indexAudio == 1)
        {
            PlayerPrefs.DeleteKey("CanEnter");
            PlayerPrefs.SetInt("SceneScript", 0);
            if (isGetFlashlight)
            {
                indexAudio++;
                PlayerPrefs.DeleteKey("SceneScript");
                PlayerPrefs.SetInt("CanEnter", 0);
            }
        }
        else if (indexAudio == 0)
        {
            indexAudio++;
            PlayerPrefs.SetInt("CanEnter", 0);
        }
        PlayerPrefs.SetInt("GamelanWhisperPlay", indexAudio);
    }
}
