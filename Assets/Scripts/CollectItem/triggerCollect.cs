using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class triggerCcollect : MonoBehaviour
{
    trashManager trashManager;
    [SerializeField] private LayerMask layerMask;
    private Ray rayMousePos;
    RaycastHit2D[] ray;
    delayTime2 delayTime2;
    bool destroyTrash = false;
    public GameObject insertObject, insertUI;


    //START----- Merubah scale dari Trash ketika terdeteksi mouse -----//
    Vector2 nowPos;
    Vector3 moveDir;
    Quaternion rotate;
    float newPos = 0.1f;
    int trigger = 0;
    private GameObject trash, trashActive, parentTrash;
    public int trashCollected = 0;
    //END//
    void Awake()
    {
        if (PlayerPrefs.HasKey("TrashCollected"))
        {
            trashCollected = PlayerPrefs.GetInt("TrashCollected");
        }
    }
    void Start()
    {
        trashManager = GetComponent<trashManager>();
        delayTime2 = GetComponent<delayTime2>();
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }
    void Raycast()
    {

        rayMousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray = Physics2D.RaycastAll(rayMousePos.origin, rayMousePos.direction, 0.1f, layerMask);

        foreach (RaycastHit2D hit in ray)
        {
            if (Input.GetMouseButtonDown(0))
            {
                trashCollected++;
                PlayerPrefs.SetInt("TrashCollected", trashCollected);
                hit.transform.GetComponent<trashEffect>().SoundEffectPick();
                hit.transform.GetComponent<SpriteRenderer>().enabled = false;
                hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                trashManager.trashCollect++;
                trashActive = hit.transform.gameObject;
                parentTrash = hit.transform.parent.gameObject;
                destroyTrash = true;
                if (insertObject != null)
                {
                    Debug.Log("hai");
                    insertObject.SetActive(true);
                }
                if (insertUI != null)
                {
                    Debug.Log("hai");
                    insertUI.SetActive(false);
                }
            }


            if (trigger == 0)
            {
                trash = hit.collider.gameObject;
                trash.GetComponent<trashEffect>().SoundEffect();
                nowPos = trash.transform.localPosition;
                rotate = trash.transform.rotation;
                moveDir = rotate * Vector3.up * newPos;
                trash.transform.localPosition += moveDir;
                trigger++;
            }
        }
        if (ray.Length <= 0)
        {
            if (trash != null)
            {
                trash.transform.localPosition = nowPos;
                trigger = 0;
                trash = null;
            }
        }
        if (destroyTrash)
        {
            if (delayTime2.Delay(0.2f))
            {
                parentTrash.GetComponent<chooseTrashInScene>().DestroyTrash = true;
                trashManager.allTrash.Remove(trash);
                Destroy(trashActive);
                parentTrash = null;
                trashActive = null;
                destroyTrash = false;
            }
        }
    }
}
