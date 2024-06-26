
using UnityEngine;


public class raycastMouseScene2 : MonoBehaviour
{
    public enum raycastForScene
    {
        Scene_Bintang_Raya,
        Scene_Hutan_Roh,
        Scene_Pemukiman,
        Scene_Hutan_Mistik,
        Scene_Jalur_Hutan,
        Scene_Jalur_Pendakian,
        Scene_Pemakaman
    }
    bool bintangRaya = false;
    public raycastForScene RaycastForScene;
    [SerializeField] eventTendOpen eventTendOpen;
    [SerializeField] transition transition;
    [SerializeField] sceneScript2 sceneScript2;
    [SerializeField] PlayerPrefsSave playerPrefsSave;
    [SerializeField] Texture2D[] cursorImage;
    [SerializeField] LayerMask layerMask;
    delayTime2 delayTime2;
    [SerializeField] int CountClick = 0;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        delayTime2 = GetComponent<delayTime2>();
    }

    // Update is called once per frame
    void Update()
    {
        ChooseRaycastForScene();
        if (bintangRaya)
        {
            if (CountClick == 1)
            {
                sceneScript2.Script2();
                if (delayTime2.Delay(0.5f))
                {
                    CountClick = 3;
                }
            }
        }

    }
    void ChooseRaycastForScene()
    {
        switch (RaycastForScene)
        {
            case raycastForScene.Scene_Bintang_Raya:
                bintangRaya = true;
                RaycastBintangRaya();
                break;
            case raycastForScene.Scene_Hutan_Roh:
                break;
            case raycastForScene.Scene_Pemukiman:
                RaycastPemukiman();
                break;
            case raycastForScene.Scene_Jalur_Hutan:
                break;
            case raycastForScene.Scene_Hutan_Mistik:
                break;
            case raycastForScene.Scene_Pemakaman:
                break;
            case raycastForScene.Scene_Jalur_Pendakian:
                break;
        }
    }
    void RaycastBintangRaya()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layerMask);
        foreach (RaycastHit2D hit2D in hit)
        {
            if (hit2D.collider.tag == "Environment/TendOpen" && !PlayerPrefs.HasKey("Scene1_Timeline"))
            {
                interactOpenTent interactOpenTent = hit2D.transform.GetComponent<interactOpenTent>();
                if (interactOpenTent.firstInteract)
                {
                    if (!transition.triggerTransition)
                    {
                        Cursor.SetCursor(cursorImage[0], Vector2.zero, CursorMode.ForceSoftware);
                    }
                    else if (transition.triggerTransition)
                    {
                        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                    }

                    if (Input.GetMouseButtonDown(0) && !DialogueManagerV2.isInteract)
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
                            if (transition != null)
                            {
                                transition.gameObject.SetActive(true);
                                transition.triggerTransition = true;
                            }
                            playerPrefsSave.SetPosPlayer(0);
                            hit2D.collider.GetComponent<eventTendOpen>().eventTrue = true;
                            FindAnyObjectByType<movementController>().interactNPC = true;

                        }
                    }
                }
                else if (!interactOpenTent.firstInteract || PlayerPrefs.HasKey("Scene1_Timeline"))
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                }

            }
            if (hit2D.collider.tag == "Campfire")
            {
                if (hit2D.collider.GetComponent<interactCampfire>().mouseCanInteract)
                {
                    Cursor.SetCursor(cursorImage[1], Vector2.zero, CursorMode.ForceSoftware);
                    if (Input.GetMouseButtonDown(0) && !DialogueManagerV2.isInteract)
                    {

                        hit2D.collider.GetComponent<DialogueManagerV2>().TriggerStartDialogue();
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
    void RaycastPemukiman()
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

                    if (!transition.triggerTransition)
                    {
                        Cursor.SetCursor(cursorImage[0], Vector2.zero, CursorMode.ForceSoftware);
                    }
                    else if (transition.triggerTransition)
                    {
                        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                    }

                    if (Input.GetMouseButtonDown(0) && !DialogueManagerV2.isInteract)
                    {
                        if (transition != null)
                        {
                            transition.gameObject.SetActive(true);
                            transition.triggerTransition = true;
                        }
                        playerPrefsSave.SetPosPlayer(0);
                        hit2D.collider.GetComponent<eventTendOpen>().eventTrue = true;
                    }
                }
                else if (!interactOpenTent.firstInteract || DialogueManagerV2.isInteract)
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
    }


}
