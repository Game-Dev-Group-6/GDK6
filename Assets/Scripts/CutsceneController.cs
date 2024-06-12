using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject mainMenuUI; // Panel atau Canvas yang berisi Title, Start, Settings, Quit
    public AudioSource backgroundMusic;
    public ParallaxScrolling parallaxScrolling; // Referensi ke script ParallaxScrolling
    public Button skipButton; // Referensi ke tombol Skip
    public float skipButtonDelay = 7f; // Waktu delay sebelum tombol skip muncul
    public float fadeDuration = 1f; // Durasi fade in

    private CanvasGroup mainMenuCanvasGroup;
    private bool cutscenePlaying = true;

    private void Start()
    {
        // Dapatkan CanvasGroup dari mainMenuUI
        if (mainMenuUI != null)
        {
            mainMenuCanvasGroup = mainMenuUI.GetComponent<CanvasGroup>();
            if (mainMenuCanvasGroup != null)
            {
                mainMenuCanvasGroup.alpha = 0f; // Sembunyikan UI dengan mengatur alpha ke 0
            }
            mainMenuUI.SetActive(false); // Sembunyikan UI menu utama saat cutscene dimulai
        }

        // Nonaktifkan parallax saat cutscene dimulai
        if (parallaxScrolling != null)
        {
            parallaxScrolling.enabled = false;
        }

        // Sembunyikan tombol skip pada awalnya
        if (skipButton != null)
        {
            skipButton.gameObject.SetActive(false);
        }

        // Mainkan cutscene saat scene dimulai
        if (playableDirector != null)
        {
            playableDirector.stopped += OnCutsceneStopped; // Event saat cutscene selesai
            playableDirector.Play();
        }

        // Mainkan musik latar belakang jika ada
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }

        // Mulai coroutine untuk menampilkan tombol skip setelah delay
        StartCoroutine(ShowSkipButtonAfterDelay(skipButtonDelay));
    }

    private void OnCutsceneStopped(PlayableDirector director)
    {
        ShowMainMenu();
    }

    public void SkipCutscene()
    {
        if (playableDirector != null && cutscenePlaying)
        {
            playableDirector.time = playableDirector.duration; // Lompat ke akhir cutscene
            playableDirector.Evaluate();
            playableDirector.Stop();
        }
    }

    private void ShowMainMenu()
    {
        cutscenePlaying = false;

        // Sembunyikan tombol skip saat cutscene selesai
        if (skipButton != null)
        {
            skipButton.gameObject.SetActive(false);
            skipButton.onClick.RemoveListener(SkipCutscene);
        }

        // Tampilkan UI menu utama dengan transisi fade in saat cutscene selesai
        if (mainMenuUI != null)
        {
            mainMenuUI.SetActive(true);
            if (mainMenuCanvasGroup != null)
            {
                StartCoroutine(FadeInCanvasGroup(mainMenuCanvasGroup, fadeDuration));
            }
        }

        // Aktifkan parallax saat cutscene selesai
        if (parallaxScrolling != null)
        {
            parallaxScrolling.enabled = true;
        }
    }

    private IEnumerator ShowSkipButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (skipButton != null)
        {
            skipButton.gameObject.SetActive(true);
            skipButton.onClick.AddListener(SkipCutscene);
        }
    }

    private IEnumerator FadeInCanvasGroup(CanvasGroup canvasGroup, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1, time / duration);
            yield return null;
        }

        canvasGroup.alpha = 1;
    }
}
