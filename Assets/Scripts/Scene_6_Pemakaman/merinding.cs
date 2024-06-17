using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merinding : MonoBehaviour
{
    [SerializeField] GameObject merindingInPlayerGameobject;
    [SerializeField] GameObject canvasBar;
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
