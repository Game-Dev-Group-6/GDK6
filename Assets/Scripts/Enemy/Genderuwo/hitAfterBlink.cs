using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitAfterBlink : MonoBehaviour
{
    public void makeAreaHit()
    {

        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, new Vector2(6f, 0.01f), 0);
        foreach (Collider2D hit2D in hit)
        {
            Debug.Log("Duar");
            if (hit2D.tag == "Player")
            {
                float x = 0.3f;
                if (hit2D.transform.position.x < transform.position.x)
                {
                    x *= -1;
                }
                if (hit2D.transform.position.x > transform.position.x)
                {
                    x *= 1;
                }
                hit2D.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, 0.01f), ForceMode2D.Impulse);
            }
        }
    }
    void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(transform.position, new Vector2(6f, 0.01f));
    }
}
