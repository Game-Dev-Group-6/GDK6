using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pocicaCombat : MonoBehaviour
{
    [SerializeField] GameObject HealthBar;
    public bool blink, IsAttack, firstBlink, secondBlink;
    [SerializeField] pocicaCombatManager pocicaCombatManager;
    public bool firstAttack, startCombat;
    Color newColor, firstColor, newColorBlink;
    Vector2 firstSize;
    [SerializeField] float speedChangeSize = 0.05f, speedChangeColor = 0.05f;
    [Range(0f, 0.1f)][SerializeField] float batasAtasBawah, speedFloat, batasKananKiri, speedFloatX;
    bool fly = false, reverseFlyY, reverseFlyX;
    public bool IsFly;
    [SerializeField] Vector2 posFly, valuePosFly;
    float valueXParticle;
    bool flipX;
    [SerializeField] ParticleSystem particle;
    Animator animator;
    [SerializeField] bool attack, attack2, move, move2;
    [SerializeField] float speedMoveToWards;
    GameObject player;
    [SerializeField] Vector2 lockPlayerPos;
    [SerializeField] Vector2 newPos;
    Rigidbody2D rb;
    delayTime2 delayTime2;
    delayBlink delayBlink;
    // Start is called before the first frame update
    void Start()
    {
        pocicaCombatManager = FindAnyObjectByType<pocicaCombatManager>();
        newColor = GetComponent<SpriteRenderer>().color;
        firstColor = newColor;
        newColorBlink = newColor;
        firstSize = transform.localScale;
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        delayTime2 = GetComponent<delayTime2>();
        delayBlink = GetComponent<delayBlink>();
    }

    // Update is called once per frame
    void Update()
    {
        if (blink)
        {
            BlinKRandom();
            if (secondBlink)
            {
                if (delayBlink.Delay(1))
                {
                    HealthBar.SetActive(true);
                    delayBlink.Timer = 0;
                    transform.localScale = firstSize;
                    secondBlink = false;
                    blink = false;
                    var SpriteRenderer = GetComponent<SpriteRenderer>();
                    SpriteRenderer.color = firstColor;
                    SpriteRenderer.enabled = true;
                    rb.isKinematic = true;
                    animator.SetBool("Hit", false);
                    animator.SetBool("IsGround", false);
                    IsFly = true;
                    fly = false;
                    particle.Stop();
                    transform.position = new Vector2(UnityEngine.Random.Range(pocicaCombatManager.batasKiri.transform.position.x, pocicaCombatManager.batasKanan.transform.position.x), UnityEngine.Random.Range(5.5f, 6.2f));
                }
            }
        }
        FlowCombat();
        ConditionFlipX();
    }
    void FlowCombat()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            var SpriteRenderer = GetComponent<SpriteRenderer>();
            SpriteRenderer.color = firstColor;
            /*  SpriteRenderer.enabled = true; */
            IsFly = true;
            animator.SetBool("Hit", false);
            animator.SetBool("IsGround", false);
            particle.Stop();
        }
        if (IsFly)
        {
            Fly();
            if (IsAttack)
            {
                if (delayTime2.Delay(3f))
                {
                    IsAttack = false;
                    attack = true;
                    IsFly = false;
                    delayTime2.Timer = 0;
                }
            }
        }
        if (attack)
        {
            if (delayTime2.Delay(1) && !move)
            {
                pocicaCombatManager.j++;
                pocicaCombatManager.pocicaAttack = false;
                move = true;
            }
            if (move)
            {
                lockPlayerPos = player.transform.position;
                LockPositionPlayer();
            }
        }
        if (attack2)
        {
            if (!move2)
            {
                if (delayBlink.Delay(0.5f))
                {
                    delayBlink.Timer = 0;
                    move2 = true;
                }
            }
            if (move2)
            {
                lockPlayerPos = player.transform.position;
                LockPositionPlayer();
                animator.SetBool("Jump", true);
                if (delayBlink.Delay(2f))
                {
                    Debug.Log("Eksekusi");
                    delayBlink.Timer = 0;
                    attack2 = false;
                    move2 = false;
                    animator.SetBool("Jump", false);
                    animator.SetBool("Hit", true);
                }
            }
        }
        if (animator.GetBool("Hit"))
        {
            ChangeSize();
        }
    }
    public void BlinKRandom()
    {
        if (newColor.a > 0 && !startCombat)
        {
            Debug.Log("StartCombat");
            newColorBlink.a -= speedChangeColor;
            GetComponent<SpriteRenderer>().color = newColorBlink;
        }
        if (newColorBlink.a <= 0 && !firstBlink)
        {
            startCombat = true;
            firstBlink = true;
            rb.isKinematic = true;
            blink = false;
            animator.SetBool("IsGround", false);
            IsFly = true;
            transform.position = new Vector2(UnityEngine.Random.Range(pocicaCombatManager.batasKiri.transform.position.x, pocicaCombatManager.batasKanan.transform.position.x), UnityEngine.Random.Range(5.5f, 6.2f));
        }
        if (firstBlink)
        {
            secondBlink = true;
        }
    }
    void ChangeColor()
    {
        if (newColor.g >= 0)
        {
            newColor.g -= speedChangeColor;
            newColor.b = newColor.g;
        }
        GetComponent<SpriteRenderer>().color = newColor;
    }
    void ChangeSize()
    {
        if (transform.localScale.x < 6)
        {
            ChangeColor();
            transform.localScale += new Vector3(speedChangeSize, speedChangeSize);
        }
        if (transform.localScale.x >= 6)
        {
            HealthBar.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = false;
            particle.Play();
            animator.SetBool("Hit", false);
            blink = true;
            BlinKRandom();
        }
    }
    void Fly()
    {
        if (!fly)
        {
            posFly = transform.position;
            valuePosFly = posFly;
            fly = true;
            batasAtasBawah = UnityEngine.Random.Range(0.05f, 0.1f);
            batasKananKiri = UnityEngine.Random.Range(0f, 0.1f);
        }
        if (fly)
        {
            //Vertical;
            if (valuePosFly.y < posFly.y + batasAtasBawah && !reverseFlyY)
            {
                valuePosFly.y += speedFloat;
                if (valuePosFly.y > posFly.y + batasAtasBawah)
                {
                    batasAtasBawah = UnityEngine.Random.Range(0.05f, 0.1f);
                    reverseFlyY = true;
                }
            }
            else if (valuePosFly.y > posFly.y - batasAtasBawah && reverseFlyY)
            {
                valuePosFly.y -= speedFloat;
                if (valuePosFly.y < posFly.y - batasAtasBawah)
                {
                    batasAtasBawah = UnityEngine.Random.Range(0.05f, 0.1f);
                    reverseFlyY = false;
                }
            }
            //Horizontal
            if (valuePosFly.x < posFly.x + batasKananKiri && !reverseFlyX)
            {
                valuePosFly.x += speedFloatX;
                if (valuePosFly.x > posFly.x + batasKananKiri)
                {
                    batasKananKiri = UnityEngine.Random.Range(0f, 0.1f);
                    reverseFlyX = true;
                }
            }
            else if (valuePosFly.x > posFly.x - batasKananKiri && reverseFlyX)
            {
                valuePosFly.x -= speedFloatX;
                if (valuePosFly.x < posFly.x - batasKananKiri)
                {
                    batasKananKiri = UnityEngine.Random.Range(0f, 0.1f);
                    reverseFlyX = false;
                }
            }
        }
        transform.position = valuePosFly;
    }
    void LockPositionPlayer()
    {
        rb.isKinematic = false;
        newPos = Vector2.MoveTowards(transform.position, new Vector2(lockPlayerPos.x, attack ? lockPlayerPos.y : transform.position.y), attack ? speedMoveToWards : 0.01f);
        transform.position = (Vector3)newPos;
    }
    void ConditionFlipX()
    {
        var shape = particle.shape;
        if (player.transform.position.x > transform.position.x && !attack)
        {
            flipX = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (player.transform.position.x < transform.position.x && !attack)
        {
            flipX = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (flipX)
        {
            valueXParticle = -0.07f;
        }
        else if (!flipX)
        {
            valueXParticle = 0.07f;
        }
        shape.position = new Vector3(valueXParticle, shape.position.y, shape.position.z);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            animator.SetBool("IsGround", true);
            if (attack)
            {
                attack = false;
                attack2 = true;
            }
            move = false;
            delayTime2.Timer = 0;
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<playerHealthManager>().TakeDamage(0.2f);
        }
    }
}


