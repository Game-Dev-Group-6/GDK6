using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    Vector2 checkpointPos;
    Rigidbody2D playerRb;
    
    void Start()
    {
        checkpointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Obstacle")) 
        {
            Die();
        }
    }

    public void UpdateCheckpoint(Vector2 pos) 
    {
        checkpointPos = pos;
    }

    

    IEnumerator Respawn(float duration) 
    {
        playerRb.velocity = new Vector2(0, 0);
        playerRb.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        transform.localScale = new Vector3(1, 1, 1);
        playerRb.simulated = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
