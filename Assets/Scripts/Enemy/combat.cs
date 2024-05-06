using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour
{
    [SerializeField]
    float speedMoveEnemy;
    Animator animator;
    SpriteRenderer gendoruwoSprite;
    public bool makeDistane = false;
    public bool enemyHit = false;
    float longDistance;

    enemyHealthBar enemyHealthBar;
    enemyTrigger enemyTrigger;
    delayTime2 delayTime2;
    enemyCombat enemyCombat;
    GameObject player;
    float distanceEnemyToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthBar = GetComponent<enemyHealthBar>();
        delayTime2 = GetComponent<delayTime2>();
        animator = GetComponent<Animator>();
        gendoruwoSprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        enemyTrigger = transform.parent.GetComponent<enemyTrigger>();
        enemyCombat = GetComponent<enemyCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceEnemyToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (enemyTrigger.combatBegin)
        {
            Combat1();
        }

        if (enemyHit)
        {
            if (enemyHealthBar.currentHealth <= 100 && enemyHealthBar.currentHealth > 80)
            {
                if (delayTime2.Delay(3f))
                {
                    enemyCombat.Shoot();
                }
            }
            if (enemyHealthBar.currentHealth <= 80)
            {

                if (delayTime2.Delay(1f))
                {
                    enemyCombat.Shoot();
                }

            }
        }




    }
    void Combat2()
    {

    }

    void Combat1()
    {
        if (distanceEnemyToPlayer < 3 && !makeDistane)
        {
            if (transform.position.x > player.transform.position.x)
            {
                makeDistane = true;
                longDistance = transform.position.x + 7;


            }
            else if (transform.position.x < player.transform.position.x)
            {

            }
        }
        if (makeDistane)
        {
            if (transform.position.x < longDistance)
            {
                gendoruwoSprite.flipX = false;
                animator.SetBool("walk", true);
                transform.Translate(Vector2.right * speedMoveEnemy * Time.deltaTime);
            }
            if (transform.position.x > longDistance)
            {
                enemyHit = true;
                animator.SetBool("walk", false);
                gendoruwoSprite.flipX = true;
                makeDistane = false;
            }

        }
    }
}
