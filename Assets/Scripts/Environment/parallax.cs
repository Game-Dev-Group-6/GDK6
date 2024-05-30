using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    [SerializeField] bool makeInfinity = true;

    private float lenghtSprite;
    [SerializeField][Range(-0.5f, 1f)] float speedBg;
    private float camX, startPos, firstPos;
    // Start is called before the first frame update
    void Start()
    {
        lenghtSprite = GetComponent<SpriteRenderer>().bounds.size.x;

        startPos = transform.position.x;
        firstPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        camX = Camera.main.transform.position.x;
        float moveBg = camX * speedBg;
        float movement = camX * (1 - speedBg);

        transform.position = new Vector3(makeInfinity ? startPos + moveBg : firstPos + moveBg, transform.position.y, transform.position.z);
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
