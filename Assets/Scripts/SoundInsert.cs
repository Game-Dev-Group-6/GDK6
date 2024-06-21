using UnityEngine;

public class SoundInsert : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Menginisialisasi AudioSource pada GameObject ini
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource tidak ditemukan pada GameObject ini.");
            }
        }
        else
        {
            Debug.Log("AudioSource berhasil diinisialisasi.");
        }
    }

    // Metode untuk memainkan suara
    public void PlaySound()
    {
        if (audioSource != null)
        {
            if (audioSource.clip != null)
            {
                audioSource.Play();
                Debug.Log("Suara dimainkan: " + audioSource.clip.name);
            }
            else
            {
                Debug.LogError("AudioClip belum diset pada AudioSource.");
            }
        }
        else
        {
            Debug.LogError("AudioSource tidak diinisialisasi.");
        }
    }
}