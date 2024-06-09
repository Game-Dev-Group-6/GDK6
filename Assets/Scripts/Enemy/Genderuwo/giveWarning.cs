using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class giveWarning : MonoBehaviour
{
    Color newColor;
    GameObject player;

    [SerializeField] GameObject warning;
    public bool show = false;
    bool reverse = false;

    // Start is called before the first frame update
    void Start()
    {
        newColor = warning.GetComponent<SpriteRenderer>().color;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ShowWarning();
    }

    void ShowWarning()
    {
        warning.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 3f);

        ChangeColor();
    }
    void ChangeColor()
    {

        if (newColor.a > 0 && !reverse)
        {
            newColor.a -= 0.05f;
            if (newColor.a <= 0)
            {
                reverse = true;
            }
        }
        else if (newColor.a < 1 && reverse)
        {
            newColor.a += 0.05f;
            if (newColor.a >= 1)
            {
                reverse = false;
            }
        }
        warning.GetComponent<SpriteRenderer>().color = newColor;

    }
}
