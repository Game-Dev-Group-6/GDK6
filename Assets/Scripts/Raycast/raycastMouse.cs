using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class raycastMouse : MonoBehaviour
{
    [SerializeField] Texture2D texture;
    public bool interactTendExit = false;
    GameObject flashLight;
    Ray ray;
    RaycastHit2D[] hit2D;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
        RayCast();
    }

    void RayCast()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit2D = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity);
        foreach (RaycastHit2D hit in hit2D)
        {
            if (hit.collider.tag == "Environment/TendExit")
            {

                if (hit.collider.GetComponent<interactExit>().getInteractMouse)
                {
                    if (Input.GetMouseButtonDown(0))
                    {

                    }
                }

            }



            if (hit.collider.tag == "FlashLight/Get")
            {
                flashLight = hit.collider.gameObject;
                flashLight.GetComponent<InteractFlashLight>().Hover();
                if (Input.GetMouseButtonDown(0))
                {

                }
            }
            else if (hit.collider.tag != "FlashLight/Get")
            {
                if (flashLight != null)
                {
                    flashLight.GetComponent<InteractFlashLight>().NotHover();
                    flashLight = null;
                }

            }
        }

        if (hit2D.Length <= 0)
        {
            if (flashLight != null)
            {
                flashLight.GetComponent<InteractFlashLight>().NotHover();
                flashLight = null;
            }

        }
    }
}
