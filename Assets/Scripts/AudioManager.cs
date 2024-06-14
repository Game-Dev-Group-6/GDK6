using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    // List untuk musik dan sound effects
    public List<AudioClip> musicClips;
    public List<AudioClip> sfxClips;

    private List<AudioSource> musicSources = new List<AudioSource>();
    private List<AudioSource> sfxSources = new List<AudioSource>();

    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Biarkan AudioManager tetap ada saat pindah scene

            // Muat volume yang disimpan
            musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Tambahkan semua audio sources dari game object dengan tag "Music" ke dalam list musicSources
        GameObject[] taggedMusicObjects = GameObject.FindGameObjectsWithTag("Music");
        foreach (GameObject obj in taggedMusicObjects)
        {
            AudioSource source = obj.GetComponent<AudioSource>();
            if (source != null)
            {
                musicSources.Add(source);
            }
        }

        // Tambahkan semua audio sources dari game object dengan tag "SFX" ke dalam list sfxSources
        GameObject[] taggedSfxObjects = GameObject.FindGameObjectsWithTag("SFX");
        foreach (GameObject obj in taggedSfxObjects)
        {
            AudioSource source = obj.GetComponent<AudioSource>();
            if (source != null)
            {
                sfxSources.Add(source);
            }
        }

        // Menambahkan AudioSource dinamis untuk setiap AudioClip yang sudah ditentukan sebelumnya
        foreach (AudioClip clip in musicClips)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = true;
            source.volume = musicVolume;
            musicSources.Add(source);
        }

        foreach (AudioClip clip in sfxClips)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = false;
            source.volume = sfxVolume;
            sfxSources.Add(source);
        }

        // Atur volume awal berdasarkan PlayerPrefs
        SetMusicVolume(musicVolume);
        SetSfxVolume(sfxVolume);
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        foreach (AudioSource source in musicSources)
        {
            source.volume = musicVolume;
        }
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSfxVolume(float volume)
    {
        sfxVolume = volume;
        foreach (AudioSource source in sfxSources)
        {
            source.volume = sfxVolume;
        }
        PlayerPrefs.SetFloat("SfxVolume", sfxVolume);
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSfxVolume()
    {
        return sfxVolume;
    }

    public void PlayMusic(int index)
    {
        if (index >= 0 && index < musicSources.Count)
        {
            musicSources[index].Play();
        }
    }

    public void PlaySfx(int index)
    {
        if (index >= 0 && index < sfxSources.Count)
        {
            sfxSources[index].Play();
        }
    }
}
