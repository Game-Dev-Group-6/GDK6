using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public float delay = 2f; // Waktu penundaan dalam detik
    public AudioSource clickAudioSource; // Referensi ke komponen AudioSource untuk click sound
    public AudioSource backgroundMusic; // Referensi ke komponen AudioSource untuk background music
    public GameObject settingsPanel; // Panel untuk pengaturan
    public GameObject creditsPanel; // Panel untuk pengaturan
    public Slider volumeSlider; // Slider untuk volume

    private void Start()
    {
        // Pastikan panel settings tidak terlihat saat memulai
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }

        // Pastikan panel settings tidak terlihat saat memulai
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false);
        }

        // Mengatur nilai awal slider
        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;
        }

        // Tambahkan listener untuk slider
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        // Pastikan background music tidak dimainkan saat start
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }
    }

    public void StartGame()
    {
        Debug.Log("StartGame called"); // Tambahkan debug log
        StartCoroutine(DelayedStartGame());
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame called"); // Tambahkan debug log
        StartCoroutine(DelayedQuitGame());
    }

    private IEnumerator DelayedStartGame()
    {
        // Mainkan efek suara klik
        if (clickAudioSource != null)
        {
            clickAudioSource.Play();
        }

        // Tunggu selama 'delay' detik
        yield return new WaitForSeconds(delay);

        // Pindah ke scene yang dituju
        Debug.Log("Loading scene: SampleScene"); // Tambahkan debug log
        SceneManager.LoadScene("SampleScene");
    }

    private IEnumerator DelayedQuitGame()
    {
        // Mainkan efek suara klik
        if (clickAudioSource != null)
        {
            clickAudioSource.Play();
        }

        // Tunggu selama 'delay' detik
        yield return new WaitForSeconds(delay);

        // Keluar dari game
        Debug.Log("Quitting game"); // Tambahkan debug log
        Application.Quit();
    }

    public void OpenSettings()
    {
        // Mainkan efek suara klik
        if (clickAudioSource != null)
        {
            clickAudioSource.Play();
        }

        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }

    public void CreditsSettings()
    {
        // Mainkan efek suara klik
        if (clickAudioSource != null)
        {
            clickAudioSource.Play();
        }

        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true);
        }
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }
}
