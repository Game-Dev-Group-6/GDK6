using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    // untuk input game objek
    public GameObject inputObject;
    public GameObject inputObject2;
    public GameObject inputObject3;

    AudioManagerTutorial audioManagerTutorial;

    void Start()
    {
        audioManagerTutorial = FindObjectOfType<AudioManagerTutorial>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (GameIsPaused)
            {
                Resume();
            }
            else
            {

                Pause();
            }
        }
    }

    public void Resume()
    {
        inputObject.SetActive(false); 
        inputObject2.SetActive(true);        
        inputObject3.SetActive(false); 
        Time.timeScale = 1f;
        GameIsPaused = false;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.UnPause();
        }

        audioManagerTutorial.SaveSoundSettings();
    }

    void Pause()
    {
        inputObject.SetActive(true);   
        inputObject2.SetActive(false);     
        Time.timeScale = 0f;
        GameIsPaused = true;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }

    }

    // Memberi parameter untuk input nama scene
    void QuitGame(string sceneName) 
    {
        // Mengatur waktu game menjadi 1 agar game jalan seperti semula
        Time.timeScale = 1f;

        // Load scene game
        SceneManager.LoadScene(sceneName);
    }
}
