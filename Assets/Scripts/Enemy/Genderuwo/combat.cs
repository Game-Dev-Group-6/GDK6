
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
    [SerializeField] GameObject warningAttack;
    delayBlink delayBlink;

    [SerializeField] float speedMoveEnemy;
    Animator animator;
    SpriteRenderer gendoruwoSprite;
    public bool makeDistanceRight = false;
    public bool makeDistanceLeft = false;
    public static bool enemyHit = false;
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
    bool lockPositionPlayer = false;
    bool delayMove = false;
    [SerializeField] bool onGround = true;
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
        player = GameObject.FindWithTag("Player");
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
            HealthManager();
            if (blink)
            {
                warningAttack.SetActive(true);
                enemyHit = false;
                Blink();
                Invisible();
                player.GetComponent<movementController>().slowMove = true;
                if (delayBlink.Delay(6))
                {
                    delayMove = true;
                    Visible();
                    blink = false;
                    player.GetComponent<movementController>().interactNPC = true;
                }
            }
            if (delayMove)
            {
                switchCamera.LookEnemy();
                if (delayBlink.Delay(4))
                {
                    player.GetComponent<movementController>().interactNPC = false;
                    player.GetComponent<movementController>().slowMove = false;
                    lockPositionPlayer = false;
                    delayMove = false;
                }
            }
            if (delayMove)
            {
                GetComponent<hitAfterBlink>().makeAreaHit();
            }
        }

    }
    void Combat2()
    {
        if (distanceEnemyToPlayer < 15 && !makeDistanceLeft && move && !delayMove || distanceEnemyToPlayer < 15 && !makeDistanceRight && move && !delayMove || startCombat)
        {
            if (!awakeCombat)
            {
                startCombat = false;
            }
            if (delayTime2.Delay(1))
            {
                if (transform.position.x > player.transform.position.x)
                {
                    makeDistanceRight = true;
                    shieldNow = treeManagerSort.treeRightEnemy[0];
                    longDistance = shieldNow.transform.position.x + 2;
                }
                else if (transform.position.x < player.transform.position.x)
                {
                    makeDistanceLeft = true;
                    shieldNow = treeManagerSort.treeLeftEnemy[0];
                    longDistance = shieldNow.transform.position.x - 2;
                }
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
            else if (transform.position.x > longDistance && onGround)
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
                makeDistanceLeft = false;
                enemyHit = true;
                move = false;
            }
        }
    }

    public int blinkRightLeft;
    [SerializeField] private bool blinkRight = false;
    [SerializeField] private bool blinkLeft = false;
    public float lockPosPlayer;
    void Blink()
    {
        if (!lockPositionPlayer)
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
                lockPosPlayer = player.transform.position.x + 2;
            }
            else if (blinkLeft)
            {
                lockPosPlayer = player.transform.position.x - 2;
            }
            lockPositionPlayer = true;
        }
        transform.position = new Vector2(lockPosPlayer, transform.position.y);
    }

    void HealthManager()
    {
        if (enemyHealthBar.currentHealth <= 100 && enemyHealthBar.currentHealth > 80)
        {
            if (!health100)
            {
                shieldActive = true;
                health100 = true;
            }
            EnemyHit(3f, 6.5f, 3f);
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
            EnemyHit(3f, 6.5f, 3f);
        }
        if (enemyHealthBar.currentHealth <= 60 && enemyHealthBar.currentHealth > 40)
        {
            if (!health60)
            {
                move = true;
                shieldActive = true;
                blink = true;
                health60 = true;
            }
            EnemyHit(3f, 6.5f, 3f);
        }
        if (enemyHealthBar.currentHealth <= 40 && enemyHealthBar.currentHealth > 20)
        {
            if (!health40)
            {
                move = true;
                shieldActive = true;
                blink = true;
                health40 = true;
            }
            EnemyHit(3f, 6.5f, 3f);
        }
        if (enemyHealthBar.currentHealth <= 20 && enemyHealthBar.currentHealth > 0)
        {
            if (!health20)
            {
                move = true;
                shieldActive = true;
                blink = true;
                health20 = true;
            }
            EnemyHit(3f, 6.5f, 3f);
        }
        if (enemyHealthBar.currentHealth <= 0)
        {
            enemyHealthBar.EnemyDead();
        }
    }

    void EnemyHit(float delayHitTree, float delayCameraAfterHitTree, float delayHitAfterCameraFollowPalyer)
    {
        if (enemyHit)
        {
            if (shieldActive)
            {
                delayForCamera = false;
                if (delayTime2.Delay(delayHitTree))
                {
                    enemyCombat.Shoot();
                }
            }
            else if (!shieldActive)
            {
                if (!delayForCamera)
                {
                    if (delayTime2.Delay(delayCameraAfterHitTree))
                    {
                        switchCamera.LookPlayer();
                        delayForCamera = true;
                    }
                }
                else if (delayForCamera)
                {
                    if (delayTime2.Delay(delayHitAfterCameraFollowPalyer))
                    {
                        enemyCombat.Shoot();
                    }
                }
            }
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
        warningAttack.SetActive(false);
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
