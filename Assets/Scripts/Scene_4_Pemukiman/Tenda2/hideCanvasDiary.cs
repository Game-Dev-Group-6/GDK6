using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideCanvasDiary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetString("Klue4", "");
                gameObject.SetActive(false);
            }
        }
    }
}
