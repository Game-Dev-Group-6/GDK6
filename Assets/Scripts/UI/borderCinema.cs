using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderCinema : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] GameObject materia;
    [SerializeField] float valueBorderY, speedHide;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        ConditionBorderActive();
    }

    // Update is called once per frame
    void Update()
    {
        ConditionBorderActive();
        material.SetFloat("_Height", valueBorderY);
    }
    void HideBorder()
    {
        if (valueBorderY <= 0.38)
        {
            valueBorderY += speedHide;
            if (valueBorderY > 0.38)
            {
                materia.SetActive(false);
            }
        }
    }
    void UnHideBorder()
    {
        if (valueBorderY >= 0.3)
        {
            valueBorderY -= speedHide;
            /* if (valueBorderY < 0.3)
            {

            } */
        }
    }
    void ConditionBorderActive()
    {
        if (PlayerPrefs.HasKey("CutScene"))
        {
            UnHideBorder();
            materia.SetActive(true);
        }
        if (!PlayerPrefs.HasKey("CutScene"))
        {
            HideBorder();
        }
    }
    public void HasKey()
    {
        PlayerPrefs.SetString("CutScene", "");
    }
    public void NotHasKey()
    {
        PlayerPrefs.DeleteKey("CutScene");
    }
}
