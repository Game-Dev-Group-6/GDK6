using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class eventTendOpen : MonoBehaviour
{
    [SerializeField] int indexScene = 1;
    [Header("Object HasveLight")]
    [SerializeField] Light2D[] allLight;
    public bool eventTrue = false;
    [SerializeField] GameObject flashLight;
    [SerializeField] GameObject Campfire;

    // Start is called before the first frame update
    void Start()
    {
        allLight = FindObjectsOfType<Light2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (eventTrue)
        {
            EventOpen();
        }
    }
    void EventOpen()
    {
        if (Campfire != null)
        {
            Campfire.GetComponent<Animator>().enabled = false;
        }
        if (flashLight != null)
        {
            flashLight.GetComponent<controlIntesityLighter>().enabled = false;
        }

        foreach (Light2D light in allLight)
        {
            if (light.intensity > 0)
            {
                light.intensity -= 0.1f;
            }
        }
        if (GetComponent<delayTime2>().Delay(3))
        {
            SceneManager.LoadScene(indexScene);
        }
    }

}
