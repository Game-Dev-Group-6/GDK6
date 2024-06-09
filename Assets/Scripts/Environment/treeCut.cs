using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeCut : MonoBehaviour
{
    bool lockFall = false;
    GameObject player;
    public bool treeFall = false;
    [SerializeField] GameObject treeNotCut, treeCutRight, treeCutLeft;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.O))
        {
            GetComponent<BoxCollider2D>().enabled = true;
            treeFall = false;
            treeCutRight.SetActive(false);
            treeNotCut.SetActive(true);
        }
    }
}
