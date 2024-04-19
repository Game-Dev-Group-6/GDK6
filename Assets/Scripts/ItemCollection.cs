using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    [SerializeField] float speedUpDown;
    Vector2 firstPos;
    [SerializeField]bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        itemFloat();
    }

    public void itemFloat()
    {
        if (transform.position.y <= firstPos.y)
        {
            reverse = false;
        }
        else if (transform.position.y >= firstPos.y + 0.05)
        {
            reverse = true;
        }

        if(reverse)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y - speedUpDown * Time.deltaTime);
        }else if(!reverse)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speedUpDown *Time.deltaTime);
        }
    }


}
