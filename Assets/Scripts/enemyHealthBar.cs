using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthBar : MonoBehaviour
{
    int i = 0;
    particleDeath particleDeath;
    float healthMax = 100;
    [SerializeField]
    float currentHealth;
    [SerializeField]
    Slider healthSlider;
    lightDamage lightDamage;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = healthMax;
        
    }  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            /*TakeDamage();*/
        }
        healthSlider.value = currentHealth / healthMax;
       
        if (currentHealth <= 0)
        {
            
            if(i == 0)
            {
                healthSlider.transform.parent.gameObject.SetActive(false);
                GetComponentInParent<SpriteRenderer>().enabled = false;
                Debug.Log("mati");
                particleDeath = transform.Find("DeathParticle").GetComponent<particleDeath>();
                particleDeath.PartcilePlay();
                i++;
            }
        }
    }

    public void TakeDamage()
    {
        lightDamage = FindAnyObjectByType<lightDamage>();
        currentHealth -= lightDamage.damage;
    }
}
