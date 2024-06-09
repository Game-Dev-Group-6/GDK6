using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderCinema : MonoBehaviour
{
    bool unHide, hide;
    [SerializeField] Material material;
    [SerializeField] GameObject materia;
    [SerializeField] float valueBorderY, speedHide;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        hide = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            hide = true;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            unHide = true;
        }
        if (hide)
        {
            HideBorder();
        }
        if (unHide)
        {
            materia.SetActive(true);
            UnHideBorder();
        }
        material.SetFloat("_Height", valueBorderY);
    }
    void HideBorder()
    {
        if (valueBorderY <= 0.4)
        {
            valueBorderY += speedHide;
            if (valueBorderY > 0.4)
            {
                hide = false;
                materia.SetActive(false);
            }
        }
    }
    void UnHideBorder()
    {
        if (valueBorderY >= 0.3)
        {
            valueBorderY -= speedHide;
            if (valueBorderY < 0.3)
            {
                unHide = false;
            }
        }
    }
}
