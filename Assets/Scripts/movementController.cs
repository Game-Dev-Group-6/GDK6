using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class movementController : MonoBehaviour
{
    [Header("Kedip")]
    [SerializeField] bool random = false;

    [Header("Jump")]
    [SerializeField]float time,curentTime;
    public bool ground = false;
    [SerializeField] float powerJump;
    Rigidbody2D rb;
    int valueRandom;

    [Header("Movement")]
    Vector2 direction;
    [SerializeField]float move,speed;
    Animator anim;
    SpriteRenderer sprite;
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerStay();
        MoveHorizontal();
        Jump();
    }
    void MoveHorizontal()
    {
        move = Input.GetAxis("Horizontal");
        direction = new Vector2(move, 0) * speed * Time.deltaTime;
        if(Mathf.Abs(move) > 0 ) {
            anim.SetBool("Kedip", false);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        //arah animasi 
        if(move > 0){
            sprite.flipX = false;
        }else if(move< 0){
            sprite.flipX=true;
        }
        transform.Translate(direction);
    }

    public void AnimasiIdle()
    {
        anim.SetBool("Kedip", false);
    }
    void PlayerStay()
    {
        if (!random)
        {
            valueRandom = UnityEngine.Random.Range(3, 7);
            random = true;
        }
        if (!Input.anyKey) {
            time = Time.time - curentTime;
            if(time > valueRandom)
            {
                anim.SetBool("Kedip",true);
                random = false;
                time = 0;
                curentTime = Time.time;
            }
        }
        else if (Input.anyKeyDown)
        {
            time = 0;
            curentTime = Time.time;
        }
       
        
    }

    void Jump()
    {
         if(Input.GetKeyDown(KeyCode.Space) && ground == true) {
            rb.velocity = new Vector2(0,1) * powerJump;
            anim.SetBool("IsJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            ground = true;
            anim.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            ground = false;
        }
    }

}