using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSfxManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    AudioSource walk;

    // Start is called before the first frame update
    void Start()
    {
        walk = GetComponent<AudioSource>();
    }

    public void leftLegs()
    {
        walk.clip = audioClips[2];
        walk.Play();
    }
    public void rightLegs()
    {
        walk.clip = audioClips[1];
        walk.Play();
    }
}
