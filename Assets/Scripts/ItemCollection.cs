using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    int i = 0;
    ItemCollection itemCollection;

    [SerializeField] float speedUpDown;
    Vector2 firstPos;
    [SerializeField] bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        itemCollection = GetComponent<ItemCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemCollection.enabled)
        {
            if (i <= 1)
            {
                firstPos = transform.position;
                i++;
            }
            itemFloat();
        }

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

        if (reverse)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speedUpDown * Time.deltaTime);
        }
        else if (!reverse)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speedUpDown * Time.deltaTime);
        }
    }


}
