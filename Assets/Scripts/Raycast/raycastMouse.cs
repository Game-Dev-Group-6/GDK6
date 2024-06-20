using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class raycastMouse : MonoBehaviour
{
    [SerializeField] transition Transition;
    [SerializeField] GameObject CanvasGetFlashlight, DiaryBook;
    eventExitTend eventExitTend;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Texture2D[] textures;
    public bool interactTendExit = false;
    GameObject flashLight, diary;
    [SerializeField] GameObject getCanvasFlashlightYellow;
    [SerializeField] bool flashLightYellow;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
        CursorChange();
        if (getCanvasFlashlightYellow != null)
        {
            if (getCanvasFlashlightYellow.activeSelf)
            {
                flashLightYellow = true;
            }
            else if (!getCanvasFlashlightYellow.activeSelf)
            {
                flashLightYellow = false;
            }
        }
    }

    void CursorChange()
    {
        eventExitTend = GetComponent<eventExitTend>();
        if (FindAnyObjectByType<interactExit>().getInteractMouse && interactTendExit && !eventExitTend.triggerEventExitTend)
        {
            Cursor.SetCursor(textures[1], Vector2.zero, CursorMode.ForceSoftware);
        }
        if (eventExitTend.triggerEventExitTend)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if (!FindAnyObjectByType<interactExit>().getInteractMouse)
        {
            if (flashLight != null)
            {
                Cursor.SetCursor(textures[0], Vector2.zero, CursorMode.ForceSoftware);
            }
            else if (flashLight == null)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            }
        }
    }
    void RayCast()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layerMask);
        foreach (RaycastHit2D hit2D in hit)
        {
            Debug.Log(hit2D.collider.name);
            if (hit2D.collider.tag == "Environment/TendExit" && !GetComponent<eventExitTend>().triggerEventExitTend && !flashLightYellow && !PlayerPrefs.HasKey("Scene1_Timeline"))
            {
                interactTendExit = true;
                if (hit2D.collider.GetComponent<interactExit>().getInteractMouse)
                {
                    if (Input.GetMouseButtonDown(0) && !DialogueManagerV2.isInteract)
                    {
                        gamelan.GamelanStop();
                        hit2D.collider.GetComponent<interactExit>().TentExitSFX();
                        GetComponent<eventExitTend>().triggerEventExitTend = true;
                        Transition.gameObject.SetActive(true);
                        Transition.triggerTransition = true;
                    }
                }

            }


            else if (hit2D.collider.tag == "FlashLight/Get")
            {
                interactTendExit = false;
                flashLight = hit2D.collider.gameObject;
                flashLight.GetComponent<InteractFlashLight>().Hover();
                Cursor.SetCursor(textures[0], Vector2.zero, CursorMode.ForceSoftware);
                if (Input.GetMouseButtonDown(0))
                {
                    Time.timeScale = 0;
                    CanvasGetFlashlight.GetComponent<getFlashLight>().canvasActive = true;
                }
            }
            else if (hit2D.collider.tag == "Diary")
            {
                PlayerPrefs.SetString("ShowTrashInBintangRaya", "");
                interactTendExit = false;
                diary = hit2D.collider.gameObject;
                diary.GetComponent<InteractFlashLight>().hover = true;
                Cursor.SetCursor(textures[0], Vector2.zero, CursorMode.ForceSoftware);
                if (Input.GetMouseButtonDown(0))
                {
                    diary.GetComponent<InteractFlashLight>().InteractDiary();
                }
                Debug.Log("Ini diary");
            }
            else if (hit2D.collider.tag != "FlashLight/Get" || hit2D.collider.tag != "Environment/TendExit" || hit2D.collider.tag != "Diary" || DialogueManagerV2.isInteract)
            {
                interactTendExit = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                if (flashLight != null)
                {
                    flashLight.GetComponent<InteractFlashLight>().NotHover();
                    flashLight = null;
                }
                if (diary != null)
                {
                    diary.GetComponent<InteractFlashLight>().hover = false;
                    diary = null;
                }

            }
        }

        if (hit.Length <= 0 || DialogueManagerV2.isInteract || PlayerPrefs.HasKey("Scene1_Timeline"))
        {
            interactTendExit = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            if (flashLight != null)
            {
                flashLight.GetComponent<InteractFlashLight>().NotHover();
                flashLight = null;
            }
            if (diary != null)
            {
                diary.GetComponent<InteractFlashLight>().hover = false;
                diary = null;
            }

        }
    }
    public void ClickOpenTent()
    {
        GetComponent<eventExitTend>().triggerEventExitTend = true;
        gamelan.GamelanStop();
    }
    public void ClickOpenTent2()
    {
        GetComponent<eventExitTend>().triggerEventExitTend = true;
        gamelan.GamelanStop();
    }
}
