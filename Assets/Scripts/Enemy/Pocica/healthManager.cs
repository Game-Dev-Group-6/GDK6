using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{
    public UnityEvent onCustomEvent;
    public GameObject deathParticleDelete;
    pocicaCombatManager pocicaCombatManager;
    float maxHealth = 100;
    float currentHealth;
    [SerializeField] Slider slider;
    bool onePlayParticle;
    public bool deathPartcile;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        pocicaCombatManager = FindAnyObjectByType<pocicaCombatManager>();
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
        if (currentHealth < 1)
        {

            pocicaCombatManager.j = 0;
            pocicaCombatManager.pocicaCombatss.Remove(gameObject.GetComponent<pocicaCombat>());
            GetComponent<ParticleSystem>().Stop();
            if (!onePlayParticle)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                slider.gameObject.SetActive(false);
                deathPartcile = true;
                onePlayParticle = true;
            }
            if (onePlayParticle)
            {
                if (GetComponent<delayTime2>().Delay(2))
                {
                    Debug.Log("Destroy");
                    Destroy(gameObject);
                }
                else
                {
                    if (gameObject != null)
                    {
                        if (onCustomEvent != null) 
                        {
                            onCustomEvent.Invoke();
                        }
                        // Destroy setelah 2 detik
                        Destroy(gameObject, 2);
                        Debug.Log("Destroy setelah 2 detik");
                        Destroy(deathParticleDelete, 2);
                    }
                }
            }

        }
    }
}
