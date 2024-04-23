using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lightDamage : MonoBehaviour
{
    particleEffect[] particleEffect;
    delayTime delayTime;
    [SerializeField]
    LayerMask musuh;
    Vector2 mousePos;
    Vector2 lightPos;
    RaycastHit2D[] ray;
    Light2D light2D;
    public float damage;
    [SerializeField]
    float raycastDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        delayTime = GetComponent<delayTime>();
    }

    // Update is called once per frame
    void Update()
    {
        light2D = GetComponent<Light2D>();
        lightPos = light2D.transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distanceToMouse = mousePos - lightPos;
        ray = Physics2D.RaycastAll(lightPos, distanceToMouse, raycastDistance, musuh);
        foreach (RaycastHit2D hit in ray)
        {
            //waktu delay untuk menentukan waktu jeda ketika musuh terkena damage
            if (delayTime.Delay(0.2f))
            {
                //memberikan damage kepada musuh
                hit.collider.gameObject.GetComponent<enemyHealthBar>().TakeDamage();

                //mememunculkan particle Hurt, menggunakan if dan for sebab particleSystem sebagai childrenObject dari objectMusuh
                if(hit.collider.transform.childCount > 0)
                {
                    for(int i=0;i<hit.collider.transform.childCount;i++)
                    {
                        Debug.Log(hit.collider.transform.GetChild(i).name);
                        if(hit.collider.transform.GetChild(i).name == "HurtParticle")
                        {
                            hit.collider.transform.GetChild(i).GetComponent<particleEffect>().PartcilePlay();
                        }
                    }
                }
            }
           
        }if(ray.Length <= 0) {
            particleEffect = GetComponents<particleEffect>();
            foreach (particleEffect particle in particleEffect)
            {
                particle.PartcileStop();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distance  = mouse - lightPos;
        Gizmos.color = Color.blue;
        ray = Physics2D.RaycastAll(lightPos,distance, raycastDistance,musuh);
        foreach (RaycastHit2D hit in ray)
        {

            Gizmos.DrawLine(lightPos, hit.point);
        }
    }
}
