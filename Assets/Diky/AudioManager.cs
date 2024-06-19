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
            for (int i = 0; i < soundMusicList.Length; i++) 
            {
                Debug.Log("Masuk Music");
                soundMusicSource.clip = soundMusicList[i].clip;
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
            for (int i = 0; i < soundSFXList.Length; i++)
            {
                Debug.Log("Masuk SFX");
                soundEffectSource.clip = soundSFXList[i].clip;
            }
        }
        else
        {
            Debug.LogWarning("Audio list is empty!");
        }
    }
}
