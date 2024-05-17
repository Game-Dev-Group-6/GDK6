using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public float delay = 2f; // Waktu penundaan dalam detik
    public AudioSource clickAudioSource; // Referensi ke komponen AudioSource untuk click sound
    public GameObject settingsPanel; // Panel untuk pengaturan
    public Slider volumeSlider; // Slider untuk volume

    private void Start()
    {
        // Pastikan panel settings tidak terlihat saat memulai
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
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
    }

    public void StartGame()
    {
        StartCoroutine(DelayedStartGame());
    }

    public void QuitGame()
    {
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
}
