using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class eventTendOpen : MonoBehaviour
{
    [SerializeField] int indexScene = 1;
    public bool eventTrue = false;


    // Start is called before the first frame update
    void Start()
    {


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

        if (GetComponent<delayTime2>().Delay(3))
        {
            SceneManager.LoadScene(indexScene);
        }
    }

}
