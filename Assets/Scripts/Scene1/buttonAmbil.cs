using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAmbil : MonoBehaviour
{
    [SerializeField] GameObject flashLightIcon, flashLight;
    [SerializeField] getFlashLight getFlashLight;
    // Start is called before the first frame update

    public void CanvasNotActive()
    {
        getFlashLight.canvasActive = false;
        flashLight.SetActive(true);
        if (flashLight != null)
        {
            Destroy(flashLightIcon);
        }
    }
}
