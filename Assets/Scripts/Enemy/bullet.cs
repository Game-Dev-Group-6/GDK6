using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
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
    bool up = true;
    bool fire = false;
    float groundY;
    delayTime delay;


    // Start is called before the first frame update
    void Start()
    {
        int random = UnityEngine.Random.Range(0, 3);
        Debug.Log(random);
        GetComponent<SpriteRenderer>().sprite = sprites[random];
        lights[random].SetActive(true);
        cameraShake = FindAnyObjectByType<cameraShake>();
        delay = GetComponent<delayTime>();
        groundY = GameObject.Find("Ground").transform.position.y;
        /* StartCoroutine(); */
    }

    // Update is called once per frame
    void Update()
    {

        Transform player = GameObject.Find("Player").transform;
        Transform bulet = gameObject.transform;

        if (delay.Delay(0.000001f))
        {

            if (gameObject.transform.position.y < groundY + 7 && up)
            {
                gameObject.transform.position += (Vector3)Vector2.up * 0.1f;
                dir = player.position - bulet.position;
            }
            else
            {

                up = false;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

                if (i < 1)
                {
                    nowAngle = Mathf.Atan2(bulet.position.y * -1, bulet.position.x) * Mathf.Rad2Deg;
                    i++;
                }
                if (nowAngle > angle && !fire)
                {
                    nowAngle -= kecepatanRotasi;
                    Debug.Log("jalan");
                }
                else if (nowAngle < angle && !fire)
                {
                    nowAngle += kecepatanRotasi;
                    Debug.Log("jalan");
                }
                if ((int)nowAngle == (int)angle)
                {
                    fire = true;

                    bulet.GetComponent<BoxCollider2D>().enabled = true;
                    Rigidbody2D rb = bulet.GetComponent<Rigidbody2D>();
                    rb.AddForce(dir.normalized * 4f, ForceMode2D.Impulse);
                }

                Quaternion rotation = Quaternion.Euler(0, 0, nowAngle);
                gameObject.transform.rotation = rotation;

            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Ground" || other.collider.name == "Player")
        {
            ContactPoint2D contact = other.GetContact(0);
            Vector2 point = contact.point;

            particle = GameObject.Find("ParticleBullet").transform;
            particle.transform.position = point;
            particle.GetComponent<ParticleSystem>().Play();
            cameraShake.CameraShake();
            /* particle.GetComponent<ParticleSystem>().Stop(); */
            Destroy(gameObject);
        }

    }
}