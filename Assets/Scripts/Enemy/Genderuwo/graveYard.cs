using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graveYard : MonoBehaviour
{

    public void GiveDamage()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll((Vector3)new Vector2(transform.position.x - 0.5f, transform.position.y), new Vector2(2f, 4f), 0);
        foreach (Collider2D hit in hits)
        {
            if (hit.name == "Player")
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(3, 5), ForceMode2D.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube((Vector3)new Vector2(transform.position.x - 0.5f, transform.position.y), new Vector2(2f, 4f));
    }
    public void GraveyardFalse()
    {
        gameObject.SetActive(false);
    }
}
