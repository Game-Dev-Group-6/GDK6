using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trashManager : MonoBehaviour
{
    int startManyTrash;
    public int trashCollect = 0;
    [SerializeField] private GameObject[] trash;
    [SerializeField] public List<GameObject> allTrash;
    [SerializeField] private Text trashCount;

    void Awake()
    {
        trash = GameObject.FindGameObjectsWithTag("Trash");
        allTrash = new List<GameObject>(trash);
    }
    void Start()
    {

        startManyTrash = trash.Length;
        trash = null;
    }

    // Update is called once per frame
    void Update()
    {

        TrashCount();
    }

    void TrashCount()
    {
        trashCount.text = "Trash : " + trashCollect + "/" + startManyTrash;
    }
}
