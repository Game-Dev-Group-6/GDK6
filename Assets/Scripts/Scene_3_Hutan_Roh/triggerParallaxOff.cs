using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerParallaxOff : MonoBehaviour
{
    [SerializeField] GameObject parallaxTarget, player;

    // Update is called once per frame
    void Update()
    {
        TriggerCondition();
    }

    void TriggerCondition()
    {
        if (player.transform.position.x > transform.position.x)
        {
            parallaxTarget.GetComponent<parallax>().enabled = false;
        }

        if (player.transform.position.x > transform.position.x)
        {
            parallaxTarget.GetComponent<parallax>().enabled = true;
        }
    }
}
