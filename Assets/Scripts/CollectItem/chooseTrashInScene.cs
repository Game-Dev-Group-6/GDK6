using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseTrashInScene : MonoBehaviour
{
    public bool DestroyTrash = false;
    GameObject trash;
    public enum TrashIn
    {
        Bintang_Raya,
        Hutan_Roh,
        Jalur_Hutan,
        Hutan_Mistik,
        Pemakaman,
        Jalur_Pendakian
    }
    public TrashIn trashIn;
    // Start is called before the first frame update
    void Start()
    {

        trash = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        TrashInScene();
    }
    void TrashInScene()
    {
        switch (trashIn)
        {
            case TrashIn.Bintang_Raya:
                if (DestroyTrash)
                {
                    PlayerPrefs.SetString("DestroyTrashInBintangRaya", "");
                }
                if (PlayerPrefs.HasKey("ShowTrashInBintangRaya"))
                {
                    if (trash != null)
                    {
                        trash.SetActive(true);
                        if (PlayerPrefs.HasKey("DestroyTrashInBintangRaya"))
                        {
                            Destroy(trash);
                        }
                    }
                }
                else if (!PlayerPrefs.HasKey("ShowTrashInBintangRaya"))
                {
                    trash.SetActive(false);
                }
                break;

            case TrashIn.Hutan_Roh:
                if (DestroyTrash)
                {
                    PlayerPrefs.SetString("DestroyTrashInHutanRoh", "");
                }
                if (PlayerPrefs.HasKey("ShowTrashInHutanRoh"))
                {
                    if (trash != null)
                    {
                        trash.SetActive(true);
                        if (PlayerPrefs.HasKey("DestroyTrashInHutanRoh"))
                        {
                            Destroy(trash);
                        }
                    }
                }
                else if (!PlayerPrefs.HasKey("ShowTrashInHutanRoh"))
                {
                    trash.SetActive(false);
                }
                break;

            case TrashIn.Jalur_Hutan:
                if (DestroyTrash)
                {
                    PlayerPrefs.SetString("DestroyTrashInJalurHutan", "");
                }
                if (PlayerPrefs.HasKey("ShowTrashInJalurHutan"))
                {
                    if (trash != null)
                    {
                        trash.SetActive(true);
                        if (PlayerPrefs.HasKey("DestroyTrashInJalurHutan"))
                        {
                            Destroy(trash);
                        }
                    }
                }
                else if (!PlayerPrefs.HasKey("ShowTrashInJalurHutan"))
                {
                    trash.SetActive(false);
                }
                break;

            case TrashIn.Hutan_Mistik:
                if (DestroyTrash)
                {
                    PlayerPrefs.SetString("DestroyTrashInHutanMistik", "");
                }
                if (PlayerPrefs.HasKey("ShowTrashInHutanMistik"))
                {
                    if (trash != null)
                    {
                        trash.SetActive(true);
                        if (PlayerPrefs.HasKey("DestroyTrashInHutanMistik"))
                        {
                            Destroy(trash);
                        }
                    }
                }
                else if (!PlayerPrefs.HasKey("ShowTrashInHutanMistik"))
                {
                    trash.SetActive(false);
                }
                break;

            case TrashIn.Pemakaman:
                if (DestroyTrash)
                {
                    PlayerPrefs.SetString("DestroyTrashInPemakaman", "");
                }
                if (PlayerPrefs.HasKey("ShowTrashInPemakaman"))
                {
                    if (trash != null)
                    {
                        trash.SetActive(true);
                        if (PlayerPrefs.HasKey("DestroyTrashInPemakaman"))
                        {
                            Destroy(trash);
                        }
                    }
                }
                else if (!PlayerPrefs.HasKey("ShowTrashInPemakaman"))
                {
                    trash.SetActive(false);
                }
                break;

            case TrashIn.Jalur_Pendakian:
                if (DestroyTrash)
                {
                    PlayerPrefs.SetString("DestroyTrashInJalurPendakian", "");
                }
                if (PlayerPrefs.HasKey("ShowTrashInJalurPendakian"))
                {
                    if (trash != null)
                    {
                        trash.SetActive(true);
                        if (PlayerPrefs.HasKey("DestroyTrashInJalurPendakian"))
                        {
                            Destroy(trash);
                        }
                    }
                }
                else if (!PlayerPrefs.HasKey("ShowTrashInJalurPendakian"))
                {
                    trash.SetActive(false);
                }
                break;
        }
    }
}
