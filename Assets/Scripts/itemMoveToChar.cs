using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMoveToChar : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float speedCollect;
    Collider2D[] detectPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemCollectable();
        if (detectPlayer != null ) {
            for(int i = 0;i < detectPlayer.Length;i++)
            {
                if (detectPlayer[i].tag == "Player")
                {
                    transform.position = Vector2.MoveTowards(transform.position, detectPlayer[0].transform.position, speedCollect);
                }
            }
        }
    }

    void itemCollectable()
    {
        detectPlayer = Physics2D.OverlapCircleAll(transform.position, radius);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
