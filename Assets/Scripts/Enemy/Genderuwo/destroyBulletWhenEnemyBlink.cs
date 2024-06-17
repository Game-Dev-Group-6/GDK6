using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBulletWhenEnemyBlink : MonoBehaviour
{
    GameObject[] deleteBullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!combat.enemyHit)
        {
            deleteBullet = GameObject.FindGameObjectsWithTag("Bullet");
        }
        if (deleteBullet != null)
        {
            foreach (GameObject bullet in deleteBullet)
            {
                Destroy(bullet);
            }
        }

    }
}
