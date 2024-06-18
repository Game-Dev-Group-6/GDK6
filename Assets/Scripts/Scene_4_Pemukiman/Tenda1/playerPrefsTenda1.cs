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
    public void SetPlayerPrefs()
    {
        PlayerPrefs.SetString("AfterMelati", "");
    }
}
