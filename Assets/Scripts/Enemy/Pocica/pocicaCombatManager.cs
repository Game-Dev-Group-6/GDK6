using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pocicaCombatManager : MonoBehaviour
{
    [SerializeField] GameObject jumpScareTrigger; bool IsTriggerJumpScare;
    [SerializeField] GameObject[] healthBar;
    public bool pocicaAttack;
    public int i = 0;
    public int j = 0;
    public bool startCombat, begins;
    public GameObject batasKanan, batasKiri;
    [SerializeField] public List<pocicaCombat> pocicaCombatss = new List<pocicaCombat>();
    [SerializeField] int countPocica;
    delayTime2 delayTime2;
    delayBlink delayBlink;
    [SerializeField] GameObject UITrash, UIClue;
    // Start is called before the first frame update
    void Start()
    {
        delayTime2 = GetComponent<delayTime2>();
        delayBlink = GetComponent<delayBlink>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            begins = true;
        }
        if (begins)
        {
            Urutan();
            conditionUIFlashlightActive.IsCombat = true;
        }
        if (startCombat)
        {
            FindAnyObjectByType<movementController>().interactNPC = false;
            if (begins)
            {
                foreach (GameObject Health in healthBar)
                {
                    Health.SetActive(true);
                }
            }
            begins = false;
            if (j < pocicaCombatss.Count)
            {
                if (!pocicaAttack)
                {
                    pocicaCombatss[j].IsAttack = true;
                    pocicaAttack = true;
                }
                if (pocicaCombatss[j].IsAttack)
                {
                    if (delayBlink.Delay(3f))
                    {
                        j++;
                    }
                }
            }
            if (j >= pocicaCombatss.Count)
            {
                j = 0;
            }
        }
        if (PlayerPrefs.HasKey("TriggerJumpScare"))
        {
            if (!IsTriggerJumpScare)
            {
                jumpScareTrigger.SetActive(true);
                IsTriggerJumpScare = true;
                PlayerPrefs.DeleteKey("TriggerJumpScare");
            }
        }
        ConditionPocicaLose();
    }
    void Urutan()
    {
        if (i < pocicaCombatss.Count)
        {
            pocicaCombatss[i].blink = true;
            if (pocicaCombatss[i].startCombat)
            {
                i++;
            }
        }
        if (i >= pocicaCombatss.Count)
        {
            startCombat = true;
        }
    }
    [SerializeField] GameObject Image_Transition_Canvas;
    public bool eventCameraShake, oneShake;
    void ConditionPocicaLose()
    {
        if (pocicaCombatss.Count == 0 && !eventCameraShake)
        {
            PlayerPrefs.SetInt("Kunta", 3);
            Image_Transition_Canvas.SetActive(true);
            if (conditionUIFlashlightActive.IsCombat)
            {
                FindAnyObjectByType<movementController>().interactNPC = true;
                conditionUIFlashlightActive.IsCombat = false;
            }
        }
        if (eventCameraShake)
        {
            if (!oneShake)
            {
                FindAnyObjectByType<clueButton>().klueBaru = true;
                PlayerPrefs.SetString("Klue7", "");
                FindAnyObjectByType<wallActive>().wallNonActive();
                FindAnyObjectByType<cameraShake>().CameraShake(3, 1);
                FindAnyObjectByType<movementController>().interactNPC = false;
                oneShake = true;
            }
        }
    }
}
