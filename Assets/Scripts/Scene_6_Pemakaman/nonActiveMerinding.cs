using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonActiveMerinding : MonoBehaviour
{
    GameObject parent;
    [SerializeField] GameObject canvasBar;

    void Start()
    {
        parent = transform.parent.gameObject;
    }
    public void NonActiveMerinding()
    {
        parent.SetActive(false);
        canvasBar.SetActive(true);
        FindObjectOfType<movementController>().interactNPC = false;

    }
}
