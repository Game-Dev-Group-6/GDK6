using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlColor : MonoBehaviour
{
    [Range(0, 0.5f)][SerializeField] float speedChangeColor;
    bool reverse = false;
    [SerializeField] Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        newColor = GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
        GetComponent<Text>().color = newColor;
    }
    void ChangeColor()
    {
        if (newColor.a > 0 && !reverse)
        {
            newColor.a -= speedChangeColor;
            if (newColor.a <= 0)
            {
                reverse = true;
            }
        }
        if (newColor.a < 1 && reverse)
        {
            newColor.a += speedChangeColor;
            if (newColor.a >= 1)
            {
                reverse = false;
            }
        }
    }
}
