using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class InteractFlashLight : MonoBehaviour
{
    [SerializeField] GameObject canvasDiary, canvasUIBar;

    [SerializeField] Volume volume;
    [SerializeField] DepthOfField depthOfField;
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
        if (canvasDiary != null)
        {
            if (canvasDiary.activeSelf)
            {
                Debug.Log("bLUR");

                if (volume.profile.TryGet(out depthOfField))
                {
                    canvasUIBar.SetActive(false);
                    depthOfField.focalLength.value = 300;
                    Time.timeScale = 0;
                }
            }
            else if (!canvasDiary.activeSelf)
            {
                Time.timeScale = 1;
                if (volume.profile.TryGet(out depthOfField))
                {
                    canvasUIBar.SetActive(true);
                    depthOfField.focalLength.value = 0;

                }
            }
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


    public void InteractDiary()
    {
        canvasDiary.SetActive(true);

    }
}
