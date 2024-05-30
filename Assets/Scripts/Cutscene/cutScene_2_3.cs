using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutScene_2_3 : MonoBehaviour
{
    [SerializeField] GameObject TimelineScene2To3, TimelineScene3To2;
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        CutsceneManager();
    }

    void CutsceneManager()
    {
        if (PlayerPrefs.HasKey("Scene2To3"))
        {
            Debug.Log("trigger");

            if (PlayerPrefs.GetInt("Scene2To3", 0) == 1)
            {
                player.GetComponent<SpriteRenderer>().flipX = false;
                TimelineScene2To3.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("Scene2To3", 0) == 0)
            {
                player.GetComponent<SpriteRenderer>().flipX = true;
                TimelineScene3To2.SetActive(true);
            }
        }
    }
}
