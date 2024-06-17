using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    combat combat;
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    GameObject[] lights;
    cameraShake cameraShake;
    Transform particle;
    Vector2 dir;
    float nowAngle;
    int i = 0;
    [SerializeField]
    int kecepatanRotasi = 0;
    bool pushUp = true;
    bool fire = false;
    float groundY;
    delayTime2 delay;


    void Start()
    {
        // START ----- Make Random Sprite for Ranting -----//
        int random = UnityEngine.Random.Range(0, 3);
        GetComponent<SpriteRenderer>().sprite = sprites[random];
        lights[random].SetActive(true);
        // END //

        combat = FindAnyObjectByType<combat>();
        cameraShake = FindAnyObjectByType<cameraShake>();
        delay = GetComponent<delayTime2>();
        groundY = GameObject.FindWithTag("Ground").transform.position.y;
    }

    void Update()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        Transform bulet = gameObject.transform;

        if (delay.Delay(0.0000000001f))
        {
            if (gameObject.transform.position.y < groundY + 7 && pushUp)
            {
                gameObject.transform.position += (Vector3)Vector2.up * 0.3f;
                if (combat != null)
                {
                    if (combat.shieldActive)
                    {
                        Debug.Log("make Shield");
                        if (combat.shieldNow != null)
                        {
                            dir = combat.shieldNow.transform.position - bulet.position;
                        }
                        else if (combat.shieldNow == null)
                        {
                            combat.shieldNow = null;
                        }
                    }
                    else if (!combat.shieldActive)
                    {
                        Debug.Log("Not make Shield");
                        dir = player.position - bulet.position;
                    }
                }
            }
            else
            {
                pushUp = false;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

                if (i < 1)
                {
                    nowAngle = Mathf.Atan2(bulet.position.y, bulet.position.x) * Mathf.Rad2Deg;
                    i++;
                }
                if (nowAngle < angle && !fire)
                {
                    nowAngle += kecepatanRotasi;
                    Debug.Log("jalan");
                }
                else if (nowAngle > angle && !fire)
                {
                    nowAngle -= kecepatanRotasi;
                    Debug.Log("jalan");
                }
                if ((int)nowAngle == (int)angle)
                {
                    fire = true;

                    bulet.GetComponent<BoxCollider2D>().enabled = true;
                    Rigidbody2D rb = bulet.GetComponent<Rigidbody2D>();
                    rb.AddForce(dir.normalized * 1f, ForceMode2D.Impulse);
                    detectHit();
                }
                Quaternion rotation = Quaternion.Euler(0, 0, nowAngle);
                gameObject.transform.rotation = rotation;
            }
        }
    }
    bool rightOfPlayer = true;
    void PositionBullet()
    {
        if (transform.position.x < GameObject.FindWithTag("Player").transform.position.x)
        {
            rightOfPlayer = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Ground")
        {
            ContactPoint2D contact = other.GetContact(0);
            Vector2 point = contact.point;

            particle = GameObject.Find("ParticleBullet").transform;
            particle.transform.position = point;
            particle.GetComponent<ParticleSystem>().Play();
            cameraShake.CameraShake(1, 1);
            /* particle.GetComponent<ParticleSystem>().Stop(); */
            Destroy(gameObject);
        }
        if (other.collider.name == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }


    }

    void detectHit()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.5f, 0.5f), transform.eulerAngles.z);
        foreach (Collider2D hitTo in hit)
        {
            if (hitTo.tag == "Tree")
            {
                if (combat.shieldActive)
                {
                    hitTo.GetComponent<treeCut>().treeFall = true;
                }
                combat.shieldActive = false;
                Destroy(gameObject);
            }
            if (hitTo.tag == "Player")
            {
                hitTo.GetComponent<Rigidbody2D>().AddForce(new Vector2(rightOfPlayer ? -2 : 2, 0.1f), ForceMode2D.Impulse);
                hitTo.GetComponent<playerHealthManager>().TakeDamage(6);
                cameraShake.CameraShake(1, 1);
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        float angle = transform.eulerAngles.z;

        // Simpan matriks Gizmos sebelumnya
        Matrix4x4 originalMatrix = Gizmos.matrix;

        // Atur Gizmos.matrix ke matriks transformasi objek (posisi, rotasi, skala)
        Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.Euler(0, 0, angle), Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(1.5f, 0.5f, 0));
        Gizmos.matrix = originalMatrix;

    }
}
