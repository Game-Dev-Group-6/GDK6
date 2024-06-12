using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventKuntaActive : MonoBehaviour
{
    [SerializeField] GameObject timeline, triggerJumpscare;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ListEvent();
    }
    void ListEvent()
    {
        if (!PlayerPrefs.HasKey("Kunta1"))
        {
            timeline.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("Kunta1"))
        {
            timeline.SetActive(false);
        }

        if (PlayerPrefs.HasKey("Kunta3"))
        {
            triggerJumpscare.SetActive(true);
        }
        else if (!PlayerPrefs.HasKey("Kunta3"))
        {
            triggerJumpscare.SetActive(false);
        }
    }
}
