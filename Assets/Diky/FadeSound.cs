using System.Collections;
using UnityEngine;

public class FadeSound : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
        StartCoroutine(Fade(true, source, 2f, 1f));
        StartCoroutine(Fade(false, source, 2f, 0f));

    }

    // Update is called once per frame
    private void Update()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }

    public IEnumerator Fade(bool fadeIn, AudioSource source, float duration, float targetVolume)
    {
        if (!fadeIn)
        {
            double lengthOfSource = (double)source.clip.samples / source.clip.frequency;
            yield return new WaitForSecondsRealtime((float)(lengthOfSource - duration));
        }

        float time = 0f;
        float startVol = source.volume;
        while (time < duration)
        {
            string fadeSituation = fadeIn?"fadeIn" : "fadeOut";
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, targetVolume, time / duration);
            yield return null;
        }
    }
}
