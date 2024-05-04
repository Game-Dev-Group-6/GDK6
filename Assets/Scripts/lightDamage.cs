using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lightDamage : MonoBehaviour
{
    flipXLighter flipXLighter;
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
    float raycastDistance;
    // Start is called before the first frame update
    private void Awake()
    {
        flipXLighter = FindAnyObjectByType<flipXLighter>();
    }
    void Start()
    {
        delayTime = GetComponent<delayTime>();
       
    }

    // Update is called once per frame
    void Update()
    {
        light2D = GetComponent<Light2D>();
        lightPos = light2D.transform.position;
        raycastDistance = light2D.pointLightOuterRadius;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distanceToMouse = mousePos - lightPos;
        //titik raycast dipancarkan
        Vector2 raycastDir = new Vector2(distanceToMouse.x * flipXLighter.flipXrorate, distanceToMouse.y);
        ray = Physics2D.RaycastAll(lightPos, raycastDir.normalized, raycastDistance, musuh);
        foreach (RaycastHit2D hit in ray)
        {
            //waktu delay untuk menentukan waktu jeda ketika musuh terkena damage
            if (delayTime.Delay(0.2f))
            {
                //memberikan damage kepada musuh
                hit.collider.gameObject.GetComponent<enemyHealthBar>().TakeDamage();

                //menampilkan effek particle
                transform.GetChild(0).gameObject.transform.position = hit.point;
                transform.GetChild(0).GetComponent<ParticleSystem>().Play();
               
            }
           //jika raycast tidak mendeteksi musuh, maka semua particle tidak akan dijalankan
        }if(ray.Length <= 0) {
            //mengambil semua komponen particle efek
            particleEffect = GetComponents<particleEffect>();
            foreach (particleEffect particle in particleEffect)
            {
                //semua particle dihentikan
                particle.PartcileStop();
            }
        }
    }

    private void OnDrawGizmos()
    {
        flipXLighter = FindAnyObjectByType<flipXLighter>();
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distance  = mouse - lightPos;
        Vector2 raycastDir = new Vector2(distance.x * flipXLighter.flipXrorate, distance.y);
        Gizmos.color = Color.blue;
        ray = Physics2D.RaycastAll(lightPos,raycastDir.normalized, raycastDistance , musuh);
        foreach (RaycastHit2D hit in ray)
        {
            Gizmos.DrawLine(lightPos, hit.point);
        }
    }
}
