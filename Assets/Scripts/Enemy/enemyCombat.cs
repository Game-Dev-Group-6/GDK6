using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemyCombat : MonoBehaviour
{
    [SerializeField]
    float add = 0;
    float groundY;
    [SerializeField]
    GameObject enemyBullet;
    GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        groundY = GameObject.Find("Ground").transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Shoot();
        }

    }

    public void Shoot()
    {
        float posGround = GameObject.Find("Ground").transform.position.y;
        bullet = Instantiate(enemyBullet, new Vector3(transform.position.x + UnityEngine.Random.Range(-5, 5), groundY, 0), transform.rotation);
    }
}
