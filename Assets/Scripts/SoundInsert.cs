using UnityEngine;

public class SoundInsert : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;

    void Awake()
    {
        // Menginisialisasi AudioSource pada GameObject ini
        audioSource = gameObject.GetComponent<AudioSource>();

        // Jika AudioSource belum ada, tambahkan komponen tersebut
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Menetapkan AudioClip ke AudioSource
        audioSource.clip = audioClip;
    }

    // Metode untuk memainkan suara
    public void PlaySound()
    {
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioClip tidak tersedia.");
        }
    }
}
