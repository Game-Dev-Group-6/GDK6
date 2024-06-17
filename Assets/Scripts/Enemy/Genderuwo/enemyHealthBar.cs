using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthBar : MonoBehaviour
{
    int i = 0;
    private float healthMax = 100;
    [SerializeField] public float currentHealth;
    [SerializeField] Slider healthSlider;
    [SerializeField] private float damageFromLight = 1;
    [SerializeField] private bool dead = false;
    private lightDamage lightDamage;
    private delayTime2 delayTime2;
    private particleDeath particleDeath;
    combat combat;



    // Start is called before the first frame update
    void Start()
    {
        combat = GetComponent<combat>();
        currentHealth = healthMax;
        delayTime2 = GetComponent<delayTime2>();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth / healthMax;

        if (currentHealth <= 1)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            if (i == 0)
            {
                GetComponentInParent<SpriteRenderer>().enabled = false;
                Debug.Log("mati");
                particleDeath = transform.Find("DeathParticle").GetComponent<particleDeath>();
                if (particleDeath != null)
                {
                    particleDeath.PartcilePlay();
                }
                i++;
            }
            dead = true;
        }
    }

    public void TakeDamage()
    {
        if (combat.enemyCanHit)
        {
            lightDamage = FindAnyObjectByType<lightDamage>();
            currentHealth -= lightDamage.damage;
        }
    }

    public void EnemyDead()
    {
        if (delayTime2.Delay(5f))
        {
            Destroy(transform.parent.gameObject);
        }
        //mengambil object parent, karena object poci merupakan children

    }
}
