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
        if (PlayerPrefs.HasKey("AfterMelati") && !PlayerPrefs.HasKey("Kunta"))
        {
            PlayerPrefs.SetInt("Kunta", 2);
            Debug.Log("TimelineActive");
            timeline.SetActive(true);
        }
        else if (!PlayerPrefs.HasKey("AfterMelati") || PlayerPrefs.HasKey("Kunta"))
        {
            Debug.Log("NonTimelineActive");
            timeline.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Kunta") == 3)
        {
            triggerJumpscare.SetActive(true);
            PlayerPrefs.SetInt("Kunta", 4);
        }
        else if (PlayerPrefs.GetInt("Kunta") != 3)
        {
            triggerJumpscare.SetActive(false);
        }
    }
    public void MakeEventPlayerPrefs()
    {
        PlayerPrefs.SetString("Kunta2", "");
    }
}
