using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeCutMakeCameraShake : MonoBehaviour
{
    cameraShake cameraShake;
    [SerializeField] GameObject Durability;

    public void MakeShake()
    {
        cameraShake = FindAnyObjectByType<cameraShake>();
        cameraShake.CameraShake(1,1);
        Durability.GetComponent<treeDurability>().durabilityActive = true;
    }


}
