using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class raycastMouseScene2 : MonoBehaviour
{
    [SerializeField] Texture2D cursorImage;
    [SerializeField] LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }
    void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layerMask);
        foreach (RaycastHit2D hit2D in hit)
        {
            if (hit2D.collider.tag == "Environment/TendOpen")
            {
                interactOpenTent interactOpenTent = hit2D.transform.GetComponent<interactOpenTent>();
                if (interactOpenTent.firstInteract)
                {
                    Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
                    if (Input.GetMouseButtonDown(0))
                    {
                        GetComponent<eventTendOpen>().eventTrue = true;
                    }
                }
                else if (!interactOpenTent.firstInteract)
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                }

            }
        }
        if (hit.Length <= 0)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
