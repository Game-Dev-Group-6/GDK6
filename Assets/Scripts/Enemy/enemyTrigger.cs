using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTrigger : MonoBehaviour
{
    [SerializeField]
    float rangeTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Trigger();
    }

    void Trigger()
    {
        Collider2D[] triggers = Physics2D.OverlapCircleAll(transform.position, rangeTrigger);
        foreach (Collider2D trigger in triggers)
        {
            if(trigger.tag == "Player")
            {
                Gentayangan();
                Debug.Log("Gentayangan");
            }
        }
        if (triggers.Length <= 0) {
            transform.localScale = Vector2.one * 4;
        }

    }

    void Gentayangan()
    {
        transform.localScale = Vector2.one * 7;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangeTrigger);
    }
}
