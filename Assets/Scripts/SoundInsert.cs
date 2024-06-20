using UnityEngine;

public class SoundInsert : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Menginisialisasi AudioSource pada GameObject ini
        if (audioSource == null)
        {
            Debug.LogError("AudioSource tidak ditemukan pada GameObject ini.");
        }
    }

    // Metode untuk memainkan suara
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource tidak diinisialisasi.");
        }
    }
}