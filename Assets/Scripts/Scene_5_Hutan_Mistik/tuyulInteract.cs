using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuyulInteract : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] DialogueManagerV2 dialogueManagerV2;
    [SerializeField] GameObject Penghalang;
    [SerializeField] Texture2D cursorImage;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("ShowTrashInHutanMistik", "");
    }

    // Update is called once per frame
    void Update()
    {
        KondisiPenghalang();
        RaycastBintangRaya();
        KondisiMonolog();
    }
    void KondisiPenghalang()
    {
        if (PlayerPrefs.GetInt("TrashCollected") >= 4)
        {
            Penghalang.SetActive(false);
        }
        if (PlayerPrefs.GetInt("TrashCollected") < 4)
        {
            Penghalang.SetActive(true);
        }
    }
    void KondisiMonolog()
    {
        if (dialogueManagerV2.countClickButton == dialogueManagerV2.countSentences)
        {
            dialogueManagerV2.nPCIndexI = 0;
            dialogueManagerV2.nPCIndexJ = 0;
            dialogueManagerV2.countClickButton = 0;
        }
    }
    void RaycastBintangRaya()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layerMask);
        foreach (RaycastHit2D hit2D in hit)
        {

            if (hit2D.collider.tag == "Campfire")
            {
                {
                    Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
                    if (Input.GetMouseButtonDown(0) && !DialogueManagerV2.isInteract)
                    {
                        if (PlayerPrefs.GetInt("TrashCollected") >= 4)
                        {
                            hit2D.collider.GetComponent<Animator>().SetBool("Smile", true);
                        }
                        if (PlayerPrefs.GetInt("TrashCollected") < 4)
                        {
                            hit2D.collider.GetComponent<DialogueManagerV2>().TriggerStartDialogue();
                        }

                        Debug.Log("ini campfire2");
                    }
                }
            }
        }
        if (hit.Length <= 0)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
