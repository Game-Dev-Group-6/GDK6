using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class eventExitTend : MonoBehaviour
{
    [SerializeField] int indexScene = 1;
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
            GetComponent<playerPrefs1>().SaveScene();
            if (GetComponent<delayTime2>().Delay(3))
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                SceneManager.LoadScene(indexScene);
            }
        }
    }

}
