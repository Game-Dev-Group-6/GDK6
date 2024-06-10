using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{
    float maxHealth = 100;
    float currentHealth;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)currentHealth / maxHealth;
        DeathCondition();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void DeathCondition()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
