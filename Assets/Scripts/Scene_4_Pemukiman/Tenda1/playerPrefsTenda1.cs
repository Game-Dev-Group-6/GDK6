using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPrefsTenda1 : MonoBehaviour
{
    [SerializeField] GameObject triggerDialogue, melati;
    void Awake()
    {
        if (PlayerPrefs.HasKey("AfterMelati"))
        {
            if (triggerDialogue != null && melati != null)
            {
                Destroy(triggerDialogue);
                Destroy(melati);
            }
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayerPrefs()
    {
        PlayerPrefs.SetString("AfterMelati", "");
    }
}
