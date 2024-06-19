using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cluePaper : MonoBehaviour
{
    string[] daftarKlue = { "Hutan", "Cahaya", "Dia", "Sampah1", "Sampah2", "Sampah3", "Sampah4", "Sampah5" };
    bool Klue1, Klue2, Klue3, Klue4, Klue5, Klue6, Klue7, Klue8;
    bool Klue1Done, Klue2Done, Klue3Done, Klue4Done, Klue5Done, Klue6Done, Klue7Done, Klue8Done;
    [SerializeField] GameObject[] listKlue;
    int klueActive = 0;
    int indexChild;
    [SerializeField] GameObject prefabClue;
    [SerializeField] GameObject klue;
    [SerializeField] GameObject klueSelesai;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AddClueText();
    }

    void AddClueText()
    {
        indexChild = klueSelesai.transform.GetSiblingIndex();
        if (PlayerPrefs.HasKey("Klue1"))
        {
            if (!Klue1)
            {
                listKlue[0].SetActive(true);
                Klue1 = true;
            }
            if (Klue1)
            {
                if (PlayerPrefs.HasKey("Klue1Done") && !Klue1Done)
                {
                    listKlue[0].transform.SetSiblingIndex(indexChild + 1);
                    listKlue[0].GetComponent<TextMeshProUGUI>().text = "<s>Pemukiman<s>";
                    Klue1Done = true;
                }
            }
        }
        if (PlayerPrefs.HasKey("Klue2"))
        {
            if (!Klue2)
            {
                listKlue[1].SetActive(true);
                Klue2 = true;
            }
            if (Klue2)
            {
                if (PlayerPrefs.HasKey("Klue2Done") && !Klue2Done)
                {
                    listKlue[1].transform.SetSiblingIndex(indexChild + 1);
                    listKlue[1].GetComponent<TextMeshProUGUI>().text = "<s>Cahaya<s>";
                    Klue2Done = true;
                }
            }
        }
        if (PlayerPrefs.HasKey("Klue3"))
        {
            if (!Klue3)
            {
                listKlue[2].SetActive(true);
                Klue3 = true;
            }
            if (Klue3)
            {
                if (PlayerPrefs.HasKey("Klue3Done") && !Klue3Done)
                {
                    listKlue[2].transform.SetSiblingIndex(indexChild + 1);
                    listKlue[2].GetComponent<TextMeshProUGUI>().text = "<s>Dia<s>";
                    Klue3Done = true;
                }
            }
        }
        if (PlayerPrefs.HasKey("Klue4"))
        {
            if (!Klue4)
            {
                listKlue[3].SetActive(true);
                Klue4 = true;
            }
            if (Klue4)
            {
                if (PlayerPrefs.HasKey("Klue4Done") && !Klue4Done)
                {
                    listKlue[3].transform.SetSiblingIndex(indexChild + 1);
                    listKlue[3].GetComponent<TextMeshProUGUI>().text = "<s>Sampah1<s>";
                    Klue4Done = true;
                }
            }
        }
        if (PlayerPrefs.HasKey("Klue5"))
        {
            if (!Klue5)
            {
                listKlue[4].SetActive(true);
                Klue5 = true;
            }
            if (Klue5)
            {
                if (PlayerPrefs.HasKey("Klue5Done") && !Klue5Done)
                {
                    listKlue[4].transform.SetSiblingIndex(indexChild + 1);
                    listKlue[4].GetComponent<TextMeshProUGUI>().text = "<s>Sampah2<s>";
                    Klue5Done = true;
                }
            }
        }
        if (PlayerPrefs.HasKey("Klue6"))
        {
            if (!Klue6)
            {
                listKlue[5].SetActive(true);
                Klue6 = true;
            }
            if (Klue6)
            {
                if (PlayerPrefs.HasKey("Klue6Done") && !Klue6Done)
                {
                    listKlue[5].transform.SetSiblingIndex(indexChild + 1);
                    listKlue[5].GetComponent<TextMeshProUGUI>().text = "<s>Sampah3<s>";
                    Klue6Done = true;
                }
            }
        }
        if (PlayerPrefs.HasKey("Klue7"))
        {
            if (!Klue7)
            {
                listKlue[6].SetActive(true);
                Klue7 = true;
            }
            if (Klue7)
            {
                if (PlayerPrefs.HasKey("Klue7Done") && !Klue7Done)
                {
                    listKlue[6].transform.SetSiblingIndex(indexChild + 1);
                    listKlue[6].GetComponent<TextMeshProUGUI>().text = "<s>Sampah4<s>";
                    Klue7Done = true;
                }
            }
        }
        if (PlayerPrefs.HasKey("Klue8"))
        {
            if (!Klue8)
            {
                listKlue[7].SetActive(true);
                Klue8 = true;
            }
            if (Klue8)
            {
                if (PlayerPrefs.HasKey("Klue8Done") && !Klue8Done)
                {
                    listKlue[7].transform.SetSiblingIndex(indexChild + 1);
                    listKlue[7].GetComponent<TextMeshProUGUI>().text = "<s>Sampah5<s>";
                    Klue8Done = true;
                }
            }
        }
    }
    /*
    Daftar klue
    - Hutan (HutanRoh)
    - Cahaya (Flashlight)
    - Dia (Melati)
    - Sampah1 (BintangRaya)
    - Sampah2 (JalurHutanKunta)
    - Sampah3 (HutanRoh)
    - Sampah4 (HutanMistik)
    - Sampah5 (Pemakaman)
    */

}
