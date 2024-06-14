using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public float delay = 2f; // Waktu penundaan dalam detik
    public GameObject settingsPanel; // Panel untuk pengaturan
    public GameObject creditsPanel; // Panel untuk pengaturan
    public Slider volumeMusicSlider; // Slider untuk volume musik
    public Slider volumeSfxSlider; // Slider untuk volume SFX

    private void Start()
    {
        // Pastikan panel settings tidak terlihat saat memulai
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }

        // Pastikan panel credits tidak terlihat saat memulai
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false);
        }

        // Mengatur nilai awal slider volume musik
        if (volumeMusicSlider != null)
        {
            volumeMusicSlider.value = AudioManager.Instance.GetMusicVolume();
        }

        // Tambahkan listener untuk slider volume musik
        if (volumeMusicSlider != null)
        {
            volumeMusicSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
        }

        // Mengatur nilai awal slider volume SFX
        if (volumeSfxSlider != null)
        {
            volumeSfxSlider.value = AudioManager.Instance.GetSfxVolume();
        }

        // Tambahkan listener untuk slider volume SFX
        if (volumeSfxSlider != null)
        {
            volumeSfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSfxVolume);
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
        AudioManager.Instance.PlaySfx(0);

        // Tunggu selama 'delay' detik
        yield return new WaitForSeconds(delay);

        // Pindah ke scene yang dituju
        Debug.Log("Loading scene: SampleScene"); // Tambahkan debug log
        SceneManager.LoadScene("SampleScene");
    }

    private IEnumerator DelayedQuitGame()
    {
        // Mainkan efek suara klik
        AudioManager.Instance.PlaySfx(0);

        // Tunggu selama 'delay' detik
        yield return new WaitForSeconds(delay);

        // Keluar dari game
        Debug.Log("Quitting game"); // Tambahkan debug log
        Application.Quit();
    }

    public void OpenSettings()
    {
        // Mainkan efek suara klik
        AudioManager.Instance.PlaySfx(0);

        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }

    public void CreditsSettings()
    {
        // Mainkan efek suara klik
        AudioManager.Instance.PlaySfx(0);

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

    public void PlayBackgroundMusic()
    {
        AudioManager.Instance.PlayMusic(0);
    }
}
