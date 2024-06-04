using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashEffect : MonoBehaviour
{
    
    [SerializeField]
    AudioClip[] audios;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void SoundEffect()
    {
        audioSource.clip = audios[0];
        audioSource.Play();
    }
    public void SoundEffectPick()
    {
        audioSource.clip = audios[1];
        audioSource.Play();
    }

   
}
