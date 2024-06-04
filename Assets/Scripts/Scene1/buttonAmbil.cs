using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAmbil : MonoBehaviour
{
    [SerializeField] GameObject flashlightOnBag, ConditionGetFlashLight;
    [SerializeField] getFlashLight canvasGetFlashlight;
    // Start is called before the first frame update

    public void CanvasNotActive()
    {
        canvasGetFlashlight.canvasActive = false;
        ConditionGetFlashLight.GetComponent<conditionHaveFlashlight>().flashlightWhite = true;
        if (ConditionGetFlashLight != null)
        {
            Destroy(flashlightOnBag);
        }
    }
}
