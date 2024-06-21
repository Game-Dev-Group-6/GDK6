using UnityEngine;

public class TimelinePause : MonoBehaviour
{
    public GameObject pauseObject;

    public void PauseTimeline()
    {
        pauseObject.SetActive(false);
    }

    public void PauseTimelineActivate() 
    {
        pauseObject.SetActive(true);
    }
}
