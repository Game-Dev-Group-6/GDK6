using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public enum Enemy
    {
        Pocica, Gunda
    }
    public Enemy enemy;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PickEnemy();
        }
    }
    void PickEnemy()
    {
        switch (enemy)
        {
            case Enemy.Pocica:
                PlayerPrefs.SetFloat("Scene3PosX", player.transform.position.x);
                Debug.Log("CheckpointPocica");
                break;
            case Enemy.Gunda:
                PlayerPrefs.SetFloat("Scene7PosX", player.transform.position.x);
                Debug.Log("CheckpointGunda");
                break;
        }
    }
}
