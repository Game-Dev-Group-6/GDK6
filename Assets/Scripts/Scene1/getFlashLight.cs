using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class getFlashLight : MonoBehaviour
{
    public bool canvasActive = false;
    [SerializeField] GameObject canvas;
    [SerializeField] Volume volume;
    [SerializeField] DepthOfField depthOfField;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetFlashLight();
    }
    public void GetFlashLight()
    {
        canvas.SetActive(canvasActive);
        if (canvas.activeSelf)
        {
            if (volume.profile.TryGet(out depthOfField))
            {
                Time.timeScale = 0;
                depthOfField.focalLength.value = 300;
            }
        }
        else if (!canvas.activeSelf)
        {
            if (volume.profile.TryGet(out depthOfField))
            {
                depthOfField.focalLength.value = 0;
                Time.timeScale = 1;
            }
        }
    }
}
