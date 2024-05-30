using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanternCreak : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void LanternCreak1SFX()
    {
        audioSource.clip = audioClip[0];
        audioSource.Play();
    }
    public void LanternCreak2SFX()
    {
        audioSource.clip = audioClip[1];
        audioSource.Play();
    }
}
