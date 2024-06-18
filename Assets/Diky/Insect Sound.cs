using UnityEngine.Playables;
using UnityEngine;

public class InsectSound : MonoBehaviour
{
    // Input audio
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    // Input game objek
    public GameObject inputObject;
    public PlayableDirector playableDirector;

    // Start is called before the first frame update
    void Start()
    {
        // Mengecek tahap awal pada audio
        if (audioSource1 == null)
        {
            audioSource1 = GetComponent<AudioSource>();
        }

        if (audioSource1 == null)
        {
            Debug.LogError("AudioSource is not assigned and no AudioSource component found on the GameObject.");
        }

        if (audioSource2 == null)
        {
            audioSource2 = GetComponent<AudioSource>();
        }

        if (audioSource2 == null)
        {
            Debug.LogError("AudioSource is not assigned and no AudioSource component found on the GameObject.");
        }

        // Pastikan PlayableDirector diassign di inspector
        if (playableDirector == null)
            playableDirector = GetComponent<PlayableDirector>();
    }

    // Fungsi untuk memulai sound animation 1
    public void PlayInsectFly()
    {
        if (audioSource1 != null)
        {
            audioSource1.Play();
        }
        else
        {
            Debug.LogError("Cannot play sound because AudioSource is null.");
        }
    }
    // Fungsi untuk memulai sound animation 2
    public void PlayJumptInsect()
    {
        if (audioSource2 != null)
        {
            audioSource2.Play();
        }
        else
        {
            Debug.LogError("Cannot play sound because AudioSource is null.");
        }
    }
    // Fungsi untuk menonaktifkan objek
    public void HideObject() 
    {
        inputObject.SetActive(false);
    }

    public void PlayCutscene()
    {
        // Mulai timeline cutscene
        playableDirector.Play();
    }

    // Fungsi ini dipanggil oleh signal
    public void OnCutsceneEvent()
    {
        Debug.Log("Event timeline dipicu!");
        // Tambahkan logika yang ingin kamu jalankan saat event dipicu
    }    
}
