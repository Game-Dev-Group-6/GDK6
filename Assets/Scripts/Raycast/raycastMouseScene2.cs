using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class raycastMouseScene2 : MonoBehaviour
{
    [SerializeField] eventTendOpen eventTendOpen;
    [SerializeField] transition transition;
    bool canGetFlashlight = false;
    [SerializeField] sceneScript2 sceneScript2;
    [SerializeField] PlayerPrefsSave playerPrefsSave;
    [SerializeField] Texture2D[] cursorImage;
    [SerializeField] LayerMask layerMask;
    delayTime2 delayTime2;
    [SerializeField] int CountClick = 0;
    // Start is called before the first frame update
    void Start()
    {
        delayTime2 = GetComponent<delayTime2>();
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        if (CountClick == 1)
        {
            sceneScript2.Script2();
            if (delayTime2.Delay(0.5f))
            {
                CountClick = 3;
            }

        }
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
                    Cursor.SetCursor(cursorImage[0], Vector2.zero, CursorMode.ForceSoftware);
                    if (Input.GetMouseButtonDown(0) && !DialogueManager.isInteract)
                    {

                        if (!PlayerPrefs.HasKey("CanEnter"))
                        {
                            if (CountClick == 3)
                            {
                                CountClick = 0;
                            }
                            CountClick++;
                        }
                        if (PlayerPrefs.HasKey("CanEnter"))
                        {
                            GoInsideTent();
                        }
                    }
                }
                else if (!interactOpenTent.firstInteract)
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                }

            }
            if (hit2D.collider.tag == "Campfire")
            {
                if (hit2D.collider.GetComponent<interactCampfire>().mouseCanInteract)
                {
                    Cursor.SetCursor(cursorImage[1], Vector2.zero, CursorMode.ForceSoftware);
                    if (Input.GetMouseButtonDown(0) && !DialogueManager.isInteract)
                    {

                        hit2D.collider.GetComponent<monologTrigger>().MonologTrigger();
                        Debug.Log("ini campfire2");
                    }
                }
                else if (!hit2D.collider.GetComponent<interactCampfire>().mouseCanInteract)
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

    public void GoInsideTent()
    {
        if (transition != null)
        {
            transition.gameObject.SetActive(true);
            transition.triggerTransition = true;
        }

        playerPrefsSave.SetPosPlayer(0);
        eventTendOpen.eventTrue = true;
        CountClick = 0;
        canGetFlashlight = true;
    }
}
