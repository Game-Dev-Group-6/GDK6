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

        }

    }

    public void TakeDamage()
    {
        lightDamage = FindAnyObjectByType<lightDamage>();
        currentHealth -= damageFromLight;
    }

    public void EnemyDead()
    {
        if (delayTime2.Delay(1.2f))
        {
            Destroy(transform.parent.gameObject);
        }
        //mengambil object parent, karena object poci merupakan children

    }
}
