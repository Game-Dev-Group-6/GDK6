using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyTrigger : MonoBehaviour
{
    Color newColor;
    delayTime delayTime;
    Animator animator;
    int i = 0;
    int j = 0;
    
    [SerializeField]
    [Header("Urutan: Value Range Trigger harus > Penampakan")]
    float rangeTrigger;
    [SerializeField]
    float penampakan, speedTrigger, startCombat;


    Vector2 posPlayer;
    Transform childrenObj;
    bool gentayangan = false;
  
    // Start is called before the first frame update
    void Start()
    {
        delayTime = GetComponent<delayTime>();
        childrenObj = transform.GetChild(0);
        animator = childrenObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        posPlayer = GameObject.Find("Player").transform.position;
        float distance = Vector2.Distance(gameObject.transform.position, posPlayer);
        if (distance <= rangeTrigger && distance > penampakan)
        {
            Gentayangan();
        }
        else if(distance <= penampakan && distance > startCombat)
        {
            childrenObj.transform.localScale = Vector2.one * 1;
            animator.SetBool("gentayangan", false);
            childrenObj.GetComponent<SpriteRenderer>().flipX = true;
            Penampakan();
        }
        else if(distance <= startCombat && childrenObj.GetComponent<enemyHealthBar>().currentHealth > 0)
        {
            childrenObj.transform.position = new Vector2(transform.position.x, transform.position.y);
            childrenObj.GetComponent<BoxCollider2D>().enabled = true;
            newColor.a = 1;
            childrenObj.GetComponent<SpriteRenderer>().color = newColor;
            childrenObj.transform.GetChild(0).gameObject.SetActive(true);

        }


        if (gentayangan)
        {
            childrenObj.transform.position = Vector2.MoveTowards(childrenObj.transform.position, new Vector2(transform.position.x, childrenObj.transform.position.y), speedTrigger);
        }
    }

    void Gentayangan()
    {
        childrenObj.transform.localScale = Vector2.one * 3;

        if (i < 1)
        {
            childrenObj.transform.position = Vector3.left * (rangeTrigger + 50) ;
            childrenObj.GetComponent<SpriteRenderer>().flipX = false;
            i++;
        }
        animator.SetBool("gentayangan", true);
        if (delayTime.Delay(1f))
        {
            gentayangan = true;
        }
       
        if(childrenObj.transform.position.x == transform.position.x)
        {
            gentayangan = false;
        }
    }

    void Penampakan()
    {
        childrenObj.GetComponent<ItemCollection>().enabled = true;
        childrenObj.GetComponent<Rigidbody2D>().gravityScale = 0f;
        
        if(j < 1)
        {
            childrenObj.transform.position = new Vector2(transform.position.x - (penampakan - 13f), GameObject.Find("Ground").transform.position.y + 5f);
            j++;
        }
        newColor = childrenObj.GetComponent<SpriteRenderer>().color;
        newColor.a -= 0.001f;
        childrenObj.GetComponent<SpriteRenderer>().color = newColor;
        childrenObj.GetComponent<BoxCollider2D>().enabled = false;




    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangeTrigger);
        Gizmos.DrawWireSphere(transform.position, penampakan);
        Gizmos.DrawWireSphere(transform.position, startCombat);
    }
}
