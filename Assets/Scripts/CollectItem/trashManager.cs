using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class trashManager : MonoBehaviour
{
    int startManyTrash = 6;
    public int trashCollect = 0;
    [SerializeField] private GameObject[] trash;
    [SerializeField] public List<GameObject> allTrash;
    [SerializeField] private TextMeshProUGUI trashCount;
    [SerializeField] private triggerCcollect triggerCcollect;

    void Awake()
    {
        trash = GameObject.FindGameObjectsWithTag("Trash");
        allTrash = new List<GameObject>(trash);
    }
    void Start()
    {
        trash = null;
    }

    // Update is called once per frame
    void Update()
    {
        TrashCount();
    }

    void TrashCount()
    {
        if (trashCount != null)
        {
            trashCount.text = triggerCcollect.trashCollected + "/" + startManyTrash;
        }

    }
}
