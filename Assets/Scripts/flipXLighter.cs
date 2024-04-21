using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipXLighter : MonoBehaviour
{
    public float flipXrorate;
    [SerializeField]
    GameObject flipXTrue, flipXFalse;
    [SerializeField]
    GameObject player;
    bool flip;

    [SerializeField]
    float valueX;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        flip = player.gameObject.GetComponent<SpriteRenderer>().flipX;
        valueX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if (flip)
        {
            transform.position = flipXTrue.transform.position;
            
            
            if (valueX < flipXTrue.transform.position.x)
            {
                Debug.Log("balik");
                flipXrorate = 1;
            }else if(valueX > flipXTrue.transform.position.x)
            {
                flipXrorate = -1;
            }
        }
        else
        {
            transform.position = flipXFalse.transform.position;
            if (valueX < flipXTrue.transform.position.x)
            {
                Debug.Log("balik");
                flipXrorate = -1;
            }
            else if (valueX > flipXTrue.transform.position.x)
            {
                flipXrorate = 1;
            }

        }
    }
}
