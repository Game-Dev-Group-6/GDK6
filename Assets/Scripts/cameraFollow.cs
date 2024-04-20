using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField]
    float up;
    movementController movementController;
    GameObject Player;
    Vector2 posNow;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        movementController = Player.GetComponent<movementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementController.ground)
        {
            posNow = Vector2.MoveTowards(transform.position, new Vector2(0,Player.transform.position.y + up), 0.05f);
        }
            
            
     
        transform.position = new Vector2(Player.transform.position.x, posNow.y);

    }
}
