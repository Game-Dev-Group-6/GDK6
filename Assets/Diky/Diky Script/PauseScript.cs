using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    // untuk input game objek
    public GameObject inputObject;
    public GameObject inputObject2;
    public GameObject inputObject3;
    private Animator animator;
    private Rigidbody rb;
    private MonoBehaviour script;    

    AudioManagerTutorial audioManagerTutorial;

    void Start()
    {
        audioManagerTutorial = FindObjectOfType<AudioManagerTutorial>();
        Animator animator = GetComponent<Animator>();
        Rigidbody rb = GetComponent<Rigidbody>();
        MonoBehaviour script = GetComponent<MonoBehaviour>();
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
        

        if (animator != null)
        {
            animator.enabled = true;
        }
        if (rb != null)
        {
            rb.isKinematic = false;
        }
        if (script != null)
        {
            script.enabled = true;
        }

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.UnPause();
        }

        if (audioManagerTutorial != null)
        {
            audioManagerTutorial.SaveSoundSettings();
        }
        else
        {
            Debug.LogError("audioManagerTutorial is null");
        }
    }

    void Pause()
    {
        inputObject.SetActive(true);   
        inputObject2.SetActive(false);     
        Time.timeScale = 0f;
        GameIsPaused = true;

        if (animator != null)
        {
            animator.enabled = false;
        }
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        if (script != null)
        {
            script.enabled = false;
        }

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
