using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthBar : MonoBehaviour
{
    [SerializeField]
    float damageFromLight = 1;
    [SerializeField]
    bool dead = false;
    delayTime2 delayTime2;
    int i = 0;
    particleDeath particleDeath;
    float healthMax = 100;
    [SerializeField]
    public float currentHealth;
    [SerializeField]
    Slider healthSlider;
    lightDamage lightDamage;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = healthMax;
        delayTime2 = GetComponent<delayTime2>();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth / healthMax;

        if (currentHealth <= 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            if (i == 0)
            {
                GetComponentInParent<SpriteRenderer>().enabled = false;
                Debug.Log("mati");
                particleDeath = transform.Find("DeathParticle").GetComponent<particleDeath>();
                particleDeath.PartcilePlay();
                i++;
            }
            dead = true;
        }

        if (dead == true)
        {
            if (delayTime2.Delay(3f))
            {
                EnemyDead();
            }
        }

    }

    public void TakeDamage()
    {
        lightDamage = FindAnyObjectByType<lightDamage>();
        currentHealth -= damageFromLight;
    }

    void EnemyDead()
    {
        //mengambil object parent, karena object poci merupakan children
        Destroy(transform.parent.gameObject);
    }
}
