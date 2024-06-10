using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactDiary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            transform.localPosition += (Vector3)Vector2.up * 0.1f;
            transform.localScale += (Vector3)Vector2.one * 0.3f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            transform.localPosition -= (Vector3)Vector2.up * 0.1f;
            transform.localScale -= (Vector3)Vector2.one * 0.3f;
        }
    }
}
