using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPrefs1 : MonoBehaviour
{
    [SerializeField] bool reset;
    bool flipX;
    float posY;
    bool getFlashLight;

    GameObject player, tentExit;
    Vector3 playerPos;

    void Awake()
    {
        if (reset)
        {
            ResetScene();
        }

    }
    void Start()
    {
        tentExit = GameObject.Find("2_Tent Exit");
        player = GameObject.FindWithTag("Player");
        LoadScene();
    }

    // Update is called once per frame
    void Update()
    {
        posY = player.transform.position.y;
        playerPos = tentExit.transform.position;
        flipX = player.GetComponent<SpriteRenderer>().flipX;
        if (Input.GetKeyDown(KeyCode.M))
        {
            ResetScene();
        }
    }
    public void SaveScene()
    {
        PlayerPrefs.SetFloat("posX", playerPos.x);
        PlayerPrefs.SetFloat("posY", posY);
        PlayerPrefs.SetFloat("posZ", playerPos.z);
        PlayerPrefs.SetInt("flipX", flipX ? 1 : 0);
        SceneTakeFlashLight();
        PlayerPrefs.Save();
    }


    public void LoadScene()
    {
        if (PlayerPrefs.HasKey("posX") && PlayerPrefs.HasKey("posZ") && PlayerPrefs.HasKey("flipX"))
        {
            float posX = PlayerPrefs.GetFloat("posX");
            float posZ = PlayerPrefs.GetFloat("posZ");
            float posY = PlayerPrefs.GetFloat("posY");


            player.transform.position = new Vector3(posX, posY, posZ);
            player.GetComponent<SpriteRenderer>().flipX = PlayerPrefs.GetInt("flipX", 0) == 1;
            if (PlayerPrefs.HasKey("GetFlashLight"))
            {
                getFlashLight = PlayerPrefs.GetInt("GetFlashLight", 0) == 1;
                player.transform.GetChild(0).gameObject.SetActive(getFlashLight);
                if (getFlashLight)
                {
                    Destroy(GameObject.Find("4_Bag").transform.GetChild(0).gameObject);
                }

            }

            Debug.Log("LoadScene");
        }
    }

    void ResetScene()
    {
        PlayerPrefs.DeleteAll();
    }

    void SceneTakeFlashLight()
    {
        getFlashLight = player.transform.GetChild(0).gameObject.activeSelf;
        PlayerPrefs.SetInt("GetFlashLight", getFlashLight ? 1 : 0);
    }
}
