using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handAttack : MonoBehaviour
{
    [SerializeField] public bool startCombat = false;
    private bool detectPlayer = false;
    private delayTime2 delay;
    private Vector2 contact;
    private GameObject handZombie;
    // Start is called before the first frame update
    void Start()
    {
        handZombie = transform.GetChild(0).gameObject;
        delay = GetComponent<delayTime2>();
        handZombie.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startCombat)
        {
            HandAttack();
            if (contact != null)
            {
                if (detectPlayer)
                {
                    if (delay.Delay(1f))
                    {
                        handZombie.SetActive(true);
                        handZombie.transform.position = contact;
                        detectPlayer = false;
                    }
                }
            }
        }
    }

    void HandAttack()
    {
        Collider2D[] areaHit = Physics2D.OverlapBoxAll((Vector3)new Vector2(transform.position.x, transform.position.y - 2.6f), new Vector2(5f, 0.1f), 2f);
        foreach (Collider2D hit in areaHit)
        {
            if (hit.name == "Player")
            {
                detectPlayer = true;
                Rigidbody2D rb = hit.attachedRigidbody;
                List<ContactPoint2D> contacts = new List<ContactPoint2D>();
                int contactCount = rb.GetContacts(contacts);
                for (int i = 0; i < contactCount; i++)
                {
                    Debug.Log(contacts[i].point);
                    contact = new Vector2(contacts[i].point.x, handZombie.transform.position.y);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube((Vector3)new Vector2(transform.position.x, transform.position.y - 2.6f), new Vector2(5f, 0.1f));
    }
}
