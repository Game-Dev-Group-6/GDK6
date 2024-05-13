using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeCutMakeCameraShake : MonoBehaviour
{
    cameraShake cameraShake;

    public void MakeShake()
    {
        cameraShake = FindAnyObjectByType<cameraShake>();
        cameraShake.CameraShake();
    }

}
