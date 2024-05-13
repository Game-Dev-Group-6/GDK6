using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class combat : MonoBehaviour
{
    [Header("Shield Tree")]
    public GameObject shieldNow;
    public bool shieldActive = false;
    public int number0ShiledActive = 0;

    [Header("Blink Active")]
    public bool health100, health80, health60, health40, health20;
    public bool blink = false;

    delayBlink delayBlink;

    [SerializeField] float speedMoveEnemy;
    Animator animator;
    SpriteRenderer gendoruwoSprite;
    public bool makeDistanceRight = false;
    public bool makeDistanceLeft = false;
    public bool enemyHit = false;
    public float longDistance;

    treeManagerSort treeManagerSort;
    enemyHealthBar enemyHealthBar;
    enemyTrigger enemyTrigger;
    delayTime2 delayTime2;
    enemyCombat enemyCombat;
    GameObject player;
    [SerializeField] float distanceEnemyToPlayer;
    public bool startCombat = false;
    public bool awakeCombat = false;
    bool onGround = true;
    bool move = true;
    delayCamera delayCamera;
    public bool delayForCamera = false;

    switchCamera switchCamera;
    // Start is called before the first frame update


    void Start()
    {
        delayBlink = GetComponent<delayBlink>();
        enemyHealthBar = GetComponent<enemyHealthBar>();
        delayTime2 = GetComponent<delayTime2>();
        animator = GetComponent<Animator>();
        gendoruwoSprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        enemyTrigger = transform.parent.GetComponent<enemyTrigger>();
        enemyCombat = GetComponent<enemyCombat>();
        treeManagerSort = FindAnyObjectByType<treeManagerSort>();
        delayCamera = GetComponent<delayCamera>();
        switchCamera = FindAnyObjectByType<switchCamera>();


    }

    // Update is called once per frame
    void Update()
    {

        distanceEnemyToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (enemyTrigger.combatBegin)
        {
            if (!blink)
            {
                Combat2();
            }
            Hit1();
        }
        if (blink)
        {
            enemyHit = false;
            Invisible();
            if (delayBlink.Delay(4))
            {
                Blink();
                Visible();
                blink = false;
            }
        }






    }
    void Combat2()
    {
        if (distanceEnemyToPlayer < 3 && !makeDistanceLeft && move || distanceEnemyToPlayer < 3 && !makeDistanceRight && move || startCombat)
        {
            if (!awakeCombat)
            {
                startCombat = false;
            }
            if (transform.position.x > player.transform.position.x)
            {
                makeDistanceRight = true;
                longDistance = treeManagerSort.treeRightEnemy[0].transform.position.x + 4;
                shieldNow = treeManagerSort.treeRightEnemy[0];
            }
            else if (transform.position.x < player.transform.position.x)
            {

                makeDistanceLeft = true;
                longDistance = treeManagerSort.treeLeftEnemy[0].transform.position.x - 4;
                shieldNow = treeManagerSort.treeLeftEnemy[0];
            }

        }
        if (makeDistanceRight)
        {
            if (transform.position.x < longDistance && onGround)
            {
                gendoruwoSprite.flipX = false;
                animator.SetBool("walk", true);
                GendoruwoMovement();
            }
            if (transform.position.x > longDistance && onGround)
            {
                animator.SetBool("walk", false);
                gendoruwoSprite.flipX = true;
                makeDistanceRight = false;
                enemyHit = true;
                move = false;
            }

        }
        if (makeDistanceLeft)
        {
            if (transform.position.x > longDistance && onGround)
            {
                gendoruwoSprite.flipX = true;
                animator.SetBool("walk", true);
                GendoruwoMovement();
            }
            if (transform.position.x < longDistance && onGround)
            {
                animator.SetBool("walk", false);
                gendoruwoSprite.flipX = false;
                makeDistanceRight = false;
                enemyHit = true;
                move = false;

            }

        }

    }

    public int blinkRightLeft;
    [SerializeField] private bool blinkRight = false;
    [SerializeField] private bool blinkLeft = false;
    void Blink()
    {
        blinkRightLeft = UnityEngine.Random.Range(0, 2);
        if (blinkRightLeft == 1)
        {
            blinkRight = true;
            blinkLeft = false;
        }
        if (blinkRightLeft == 0)
        {
            blinkLeft = true;
            blinkRight = false;
        }

        if (blinkRight)
        {
            float distanceRight = player.transform.position.x + 2;
            transform.position = new Vector2(distanceRight, transform.position.y);
            player.GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (blinkLeft)
        {
            float distanceLeft = player.transform.position.x - 2;
            transform.position = new Vector2(distanceLeft, transform.position.y);
            player.GetComponent<SpriteRenderer>().flipX = false;

        }
    }


    void Hit1()
    {

        if (enemyHealthBar.currentHealth <= 100 && enemyHealthBar.currentHealth > 80)
        {
            if (!health100)
            {
                shieldActive = true;
                health100 = true;
            }
            if (enemyHit)
            {
                if (shieldActive)
                {
                    if (delayTime2.Delay(3f))
                    {
                        enemyCombat.Shoot();
                    }
                }
                else if (!shieldActive)
                {
                    if (!delayForCamera)
                    {
                        if (delayTime2.Delay(6.5f))
                        {
                            switchCamera.LookPlayer();
                            delayForCamera = true;

                        }
                    }
                    else if (delayForCamera)
                    {
                        if (delayTime2.Delay(3f))
                        {
                            enemyCombat.Shoot();
                        }
                    }
                }
            }
        }
        if (enemyHealthBar.currentHealth <= 80 && enemyHealthBar.currentHealth > 60)
        {
            if (!health80)
            {
                move = true;
                shieldActive = true;
                blink = true;
                health80 = true;
            }
            if (enemyHit)
            {
                if (shieldActive)
                {
                    if (delayTime2.Delay(1.5f))
                    {
                        enemyCombat.Shoot();
                    }
                }
                else if (!shieldActive)
                {
                    if (delayTime2.Delay(3f))
                    {
                        enemyCombat.Shoot();
                    }
                }
            }
        }
        if (enemyHealthBar.currentHealth <= 60 && enemyHealthBar.currentHealth > 0)
        {
            if (!health60)
            {
                move = true;
                blink = true;
                health60 = true;
            }
            if (enemyHit)
            {
                if (delayTime2.Delay(1f))
                {
                    enemyCombat.Shoot();
                }
            }
        }
        if (enemyHealthBar.currentHealth <= 0)
        {
            enemyHealthBar.EnemyDead();
        }
    }
    void Invisible()
    {
        GetComponent<Rigidbody2D>().gravityScale = -0.1f;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    void Visible()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<Rigidbody2D>().gravityScale = 2f;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    Vector2 direction;
    void GendoruwoMovement()
    {

        if (transform.position.x > player.transform.position.x)
        {
            direction = Vector2.right;
        }
        else if (transform.position.x < player.transform.position.x)
        {
            direction = Vector2.left;
        }
        transform.Translate(direction * speedMoveEnemy * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Ground")
        {
            onGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Ground")
        {
            onGround = false;
        }
    }
}
