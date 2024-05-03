using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterNgejar : MonoBehaviour
{
    
    public float moveSpeed;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    



    // Update is called once per frame
    void Update()
    {
        if (isChasing) 
        {
            if(transform.position.x > playerTransform.position.x) 
            {
                
                transform.position += Vector3.left * moveSpeed * Time.deltaTime; 
            }
            if(transform.position.x < playerTransform.position.x) 
            {
                
                transform.position += Vector3.right * moveSpeed * Time.deltaTime; 
            }

        }

        else 
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance) 
            {
                isChasing = true;
            }
        }
        

    }
}
