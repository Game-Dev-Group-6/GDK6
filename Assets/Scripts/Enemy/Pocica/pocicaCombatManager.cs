using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pocicaCombatManager : MonoBehaviour
{
    public bool pocicaAttack;
    public int i = 0;
    public int j = 0;
    public bool startCombat, begins;
    public GameObject batasKanan, batasKiri;
    [SerializeField] pocicaCombat[] pocicaCombats;
    [SerializeField] int countPocica;
    // Start is called before the first frame update
    void Start()
    {

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
        }
        if (startCombat)
        {
            begins = false;
            if (j < pocicaCombats.Length)
            {
                if (!pocicaAttack)
                {
                    pocicaCombats[j].IsAttack = true;
                    pocicaAttack = true;
                }
            }
            if (j >= pocicaCombats.Length)
            {
                j = 0;
            }
        }
    }

    void Urutan()
    {
        if (i < pocicaCombats.Length)
        {
            pocicaCombats[i].blink = true;
            if (pocicaCombats[i].startCombat)
            {
                i++;
            }
        }
        if (i >= pocicaCombats.Length)
        {
            startCombat = true;
        }
    }
}
