using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class eventExitTend : MonoBehaviour
{
    [SerializeField] GameObject lantern, flashLight, exitTend;
    [SerializeField] Light2D[] offAllLight;
    public bool triggerEventExitTend = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TriggerTrue();

    }
    void TriggerTrue()
    {
        if (triggerEventExitTend)
        {
            GetComponent<playerPrefs>().SaveScene();
            exitTend.GetComponent<interactExit>().enabled = false;
            lantern.GetComponent<Animator>().enabled = false;
            flashLight.GetComponent<controlIntesityLighter>().enabled = false;
            foreach (Light2D light in offAllLight)
            {
                if (light.intensity > 0)
                {
                    light.intensity -= 0.1f;
                }
            }
            if (GetComponent<delayTime2>().Delay(3))
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                SceneManager.LoadScene(2);
            }
        }
    }

}
