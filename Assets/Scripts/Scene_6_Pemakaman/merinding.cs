using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merinding : MonoBehaviour
{
    [SerializeField] GameObject[] GameObjectsNonActive;
    [SerializeField] treeManagerSort treeManagerSort;
    [SerializeField] GameObject merindingInPlayerGameobject;
    [SerializeField] GameObject canvasBar;
    void Start()
    {
        if (!PlayerPrefs.HasKey("GundaLose"))
        {
            foreach (GameObject nonActive in GameObjectsNonActive)
            {
                nonActive.SetActive(true);
            }
            treeManagerSort.enabled = true;
        }
        if (PlayerPrefs.HasKey("GundaLose"))
        {
            foreach (GameObject nonActive in GameObjectsNonActive)
            {
                nonActive.SetActive(false);
            }
            treeManagerSort.enabled = false;
        }
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!PlayerPrefs.HasKey("Merinding"))
            {
                Merinding();
                PlayerPrefs.SetString("Merinding", "");
            }
        }
    }

    void Merinding()
    {
        merindingInPlayerGameobject.SetActive(true);
        canvasBar.SetActive(false);
        FindAnyObjectByType<movementController>().interactNPC = true;
    }
}
