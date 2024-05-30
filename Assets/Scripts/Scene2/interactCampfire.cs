using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class interactCampfire : MonoBehaviour
{
    Color color, firstColor;
    [SerializeField] bool reverse = false;
    [SerializeField] float speedChangeColor;
    public bool mouseCanInteract = false;
    Vector3 scaleNotHover; Vector3 posNotHover;
    Vector3 scaleHover; Vector3 posHover;
    // Start is called before the first frame update
    void Start()
    {
        firstColor = GetComponent<SpriteRenderer>().color;
        color = firstColor;
        scaleNotHover = transform.localScale;
        scaleHover = scaleNotHover + Vector3.one * 0.5f;
        posNotHover = transform.localPosition;
        posHover = new Vector3(posNotHover.x, posNotHover.y + 0.2f, posNotHover.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseCanInteract)
        {
            ChangeColor();
        }
        else if (!mouseCanInteract)
        {
            GetComponent<SpriteRenderer>().color = firstColor;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            mouseCanInteract = true;
            HoverScale();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            mouseCanInteract = false;
            transform.localPosition = posNotHover;
            transform.localScale = scaleNotHover;
            Debug.Log("scale");
        }
    }


    void HoverScale()
    {
        mouseCanInteract = true;
        transform.localPosition = posHover;
        transform.localScale = scaleHover;

    }
    public void ChangeColor()
    {
        if (color.g <= 1 && !reverse)
        {
            color.g += speedChangeColor;
            if (color.g >= 1)
            {
                reverse = true;
            }
        }
        else if (color.g > 0 && reverse)
        {
            color.g -= speedChangeColor;
            if (color.g <= 0)
            {
                reverse = false;
            }
        }
        GetComponent<SpriteRenderer>().color = color;
    }
}
