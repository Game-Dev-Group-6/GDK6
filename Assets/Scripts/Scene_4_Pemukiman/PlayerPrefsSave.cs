using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPrefsSave : MonoBehaviour
{
    [SerializeField] string SAVESCENE_posX;
    public enum PlayerPrefsScene
    {
        None, one_1, two_2, three_3, four_4, five_5, six_6, seven_7, eight_8
    }
    public PlayerPrefsScene playerPrefsScene;
    GameObject player, virtualCamera;
    string[] keyPlayerPrefs;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        virtualCamera = GameObject.FindWithTag("VirtualCamera");
        PlayerPrefsOfScene();
        if (PlayerPrefs.HasKey(SAVESCENE_posX))
        {
            Debug.Log("LoadScene");
            Debug.Log(PlayerPrefs.GetInt("Scene2PosX"));
            player.transform.position = new Vector2(PlayerPrefs.GetFloat(SAVESCENE_posX), player.transform.position.y);
            player.GetComponent<SpriteRenderer>().flipX = PlayerPrefs.GetInt("flipX", 0) == 1;
        }
    }
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void SetPosPlayer(float posXKurang)
    {
        if (player != null)
        {
            Debug.Log("SaveScene");
            Debug.Log(PlayerPrefs.GetInt("Scene2PosX"));
            PlayerPrefs.SetFloat(SAVESCENE_posX, player.transform.position.x + posXKurang);
            PlayerPrefs.SetInt("flipX", player.GetComponent<SpriteRenderer>().flipX ? 1 : 0);
        }
    }
    public void SetCamOffX(float posX)
    {
        if (virtualCamera != null)
        {
            PlayerPrefs.SetFloat("SceneCamOffX", posX);
        }
    }

    void PlayerPrefsOfScene()
    {
        switch (playerPrefsScene)
        {
            case PlayerPrefsScene.None:
                SAVESCENE_posX = null;
                Debug.Log("None");
                break;
            case PlayerPrefsScene.one_1:
                Debug.Log("Save scene1");
                SAVESCENE_posX = "Scene1PosX";
                break;

            case PlayerPrefsScene.two_2:
                Debug.Log("Save scene2");
                SAVESCENE_posX = "Scene2PosX";
                break;

            case PlayerPrefsScene.three_3:
                Debug.Log("Save scene3");
                SAVESCENE_posX = "Scene3PosX";
                break;

            case PlayerPrefsScene.four_4:
                Debug.Log("Save scene4");
                SAVESCENE_posX = "Scene4PosX";
                break;

            case PlayerPrefsScene.five_5:
                Debug.Log("Save scene5");
                SAVESCENE_posX = "Scene5PosX";
                break;

            case PlayerPrefsScene.six_6:
                Debug.Log("Save scene6");
                SAVESCENE_posX = "Scene6PosX";
                break;

            case PlayerPrefsScene.seven_7:
                Debug.Log("Save scene7");
                SAVESCENE_posX = "Scene7PosX";
                break;
            case PlayerPrefsScene.eight_8:
                Debug.Log("Save scene8");
                SAVESCENE_posX = "Scene8PosX";
                break;
        }
    }
}
