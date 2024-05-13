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

    [Header("Merubah scale trash ketika terkena mouse")]
    Vector2 nowPos;
    float newPos = 0.1f;
    [SerializeField] private GameObject trash, trashActive;
    int trigger = 0;
    Quaternion rotate;
    [SerializeField] Vector3 moveDir;
    // Start is called before the first frame update

    void Start()
    {
        trashManager = GetComponent<trashManager>();
        delayTime2 = GetComponent<delayTime2>();
    }

    // Update is called once per frame
    void Update()
    {

        rayMousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray = Physics2D.RaycastAll(rayMousePos.origin, rayMousePos.direction, Mathf.Infinity, layerMask);

        foreach (RaycastHit2D hit in ray)
        {
            if (Input.GetMouseButtonDown(0))
            {
                hit.transform.GetComponent<trashEffect>().SoundEffectPick();
                hit.transform.GetComponent<SpriteRenderer>().enabled = false;
                hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                trashManager.trashCollect++;
                trashActive = hit.transform.gameObject;
                destroyTrash = true;
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
                trashManager.allTrash.Remove(trash);
                Destroy(trashActive);
                trashActive = null;
                destroyTrash = false;
            }
        }
    }
}
