using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource soundMusicSource;
    [SerializeField] AudioSource soundAmbientSource;
    [SerializeField] AudioSource soundUISource;
    [SerializeField] AudioSource soundEffectSource;

    [Header("--------- Audio Source List ---------")]
    public AudioSource[] soundMusicList;
    public AudioSource[] soundAmbientList;
    public AudioSource[] soundUIList;
    public AudioSource[] soundSFXList;


    private void Start()
    {
        // Pastikan ada setidaknya satu AudioSource dalam daftar
        if (soundMusicList.Length > 0)
        {
            // Atur dan mainkan clip dari audioList pertama di musicSource
            if (soundMusicList[0].clip != null)
            {
                soundMusicSource.clip = soundMusicList[0].clip;
                soundMusicSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource pertama tidak memiliki AudioClip!");
            }
        }
        else
        {
            Debug.LogWarning("Audio list is empty!");
        }

        // Pastikan ada setidaknya satu AudioSource dalam daftar
        if (soundSFXList.Length > 0)
        {
            // Atur dan mainkan clip dari audioList pertama di musicSource
            if (soundSFXList[0].clip != null)
            {
                soundEffectSource.clip = soundSFXList[0].clip;
                soundEffectSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource pertama tidak memiliki AudioClip!");
            }
        }
        else
        {
            Debug.LogWarning("Audio list is empty!");
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        soundMusicSource.PlayOneShot(clip);
    }

    public void PlayAmbient(AudioClip clip)
    {
        soundAmbientSource.PlayOneShot(clip);
    }

    public void PlayUI(AudioClip clip)
    {
        soundUISource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip)
    {
        soundEffectSource.PlayOneShot(clip);       
    }    
}
