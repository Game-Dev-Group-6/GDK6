using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class rotateLighter : MonoBehaviour
{
    flipXLighter flipXLighter;
    // Start is called before the first frame update
    void Start()
    {
        flipXLighter = GetComponent<flipXLighter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x * flipXLighter.flipXrorate) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

    }
}
