using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeCut : MonoBehaviour
{
    bool lockFall = false;
    GameObject player;
    public bool treeFall = false;
    [SerializeField] GameObject treeNotCut, treeCutRight, treeCutLeft;
    combat Combat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Combat = FindAnyObjectByType<combat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Combat != null)
        {
            if (Combat.shieldActive)
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
            if (!Combat.shieldActive)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (treeFall)
        {
            if (player.transform.position.x > transform.position.x && !lockFall)
            {
                treeCutRight.SetActive(true);
                treeNotCut.SetActive(false);
                GetComponent<BoxCollider2D>().enabled = false;
                lockFall = true;
            }
            else if (player.transform.position.x < transform.position.x && !lockFall)
            {
                treeCutLeft.SetActive(true);
                treeNotCut.SetActive(false);
                GetComponent<BoxCollider2D>().enabled = false;
                lockFall = true;
            }
        }
    }
}
