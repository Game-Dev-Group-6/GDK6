using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trashFloat : MonoBehaviour
{
    [SerializeField]
    bool riseUp = false;
    public bool fallDawn = false;
    [SerializeField]
    float speedFloat,maxFloat,minFloat;
    [SerializeField]
    bool reverse = false;
    bool floatOff = true;
    RectTransform rectTransform;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rectTransform.position.y > startPos.y + maxFloat)
        {
            reverse = true;
        }
        else if (rectTransform.position.y < startPos.y - minFloat)
        {
            reverse = false;
        }
        if(reverse && floatOff)
        {
            rectTransform.position = rectTransform.position + Vector3.down * Time.deltaTime * speedFloat;
        }else if(!reverse && floatOff)
        {
            rectTransform.position = rectTransform.position + Vector3.up * Time.deltaTime * speedFloat;
        }
        if (riseUp)
        {
            rectTransform.position = rectTransform.position + Vector3.up * Time.deltaTime * 1.5f;
            if(rectTransform.position.y > startPos.y + maxFloat)
            {
                riseUp = false;
            }
        }
        if (fallDawn)
        {
            rectTransform.position = rectTransform.position + Vector3.down * Time.deltaTime;
            if (rectTransform.position.y < startPos.y - minFloat * 3)
            {
                fallDawn = false;
                riseUp = true;
            }
        }
        
    }
}
