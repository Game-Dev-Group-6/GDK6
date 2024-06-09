using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFlashLight : MonoBehaviour
{
    Vector3 firstScale;
    Vector3 moveDir, firstPos;
    Color color;
    bool hoverMouseDetect = false;
    public bool hover = false;
    Quaternion rotate;
    [Range(0f, 0.05f)][SerializeField] float speedChangeColor;
    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
        firstPos = transform.localPosition;
        firstScale = transform.localScale;
        rotate = transform.rotation;
        moveDir = rotate * Vector3.right * 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hover)
        {
            ChangeColor();
        }
    }

    bool reverse = false;
    public void ChangeColor()
    {
        if (color.r <= 1 && !reverse)
        {
            color.r += speedChangeColor;
            color.g = color.r;
            color.b = color.r;
            if (color.r >= 1)
            {
                reverse = true;
            }
        }
        else if (color.r > 0 && reverse)
        {
            color.r -= speedChangeColor;
            color.g = color.r;
            color.b = color.r;
            if (color.r <= 0)
            {
                reverse = false;
            }
        }
        GetComponent<SpriteRenderer>().color = color;
    }
    public void ChangePosition()
    {

        /* transform.localPosition += moveDir; */
        hover = true;
    }

    public void ChangePositionNormal()
    {
        /* transform.localPosition = firstPos; */
        hover = false;
    }

    public void Hover()
    {
        if (!hoverMouseDetect)
        {
            transform.localScale = transform.localScale + (Vector3)Vector2.one * 0.1f;
            hoverMouseDetect = true;
        }

    }
    public void NotHover()
    {
        if (hoverMouseDetect)
        {
            transform.localScale = firstScale;
            hoverMouseDetect = false;
        }

    }
}
