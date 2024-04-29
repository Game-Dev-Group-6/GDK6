using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogParallax : MonoBehaviour
{
    [Range(-0.001f,-0.005f)]
    [SerializeField]
    float speedFog;
    [SerializeField]
    float lenghtSprite;
    [SerializeField]
    [Range(0f, 1f)]
    float speedBg;
    float camX, startPos;
    // Start is called before the first frame update
    void Start()
    {
        lenghtSprite = GetComponent<SpriteRenderer>().bounds.size.x;

        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        camX = Camera.main.transform.position.x;
        float moveBg = camX * speedBg;
        startPos += speedFog;
        float movement = camX * (1 - speedBg);

        transform.position = new Vector3(startPos + moveBg, transform.position.y, transform.position.z) + Vector3.left;
        if (movement > startPos + lenghtSprite)
        {
            startPos += lenghtSprite;
        }
        else if (movement < startPos - lenghtSprite)
        {
            startPos -= lenghtSprite;
        }
        


    }
}
