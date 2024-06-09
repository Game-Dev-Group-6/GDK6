using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSpriteFlashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlightYellow, flashlightWhite;
    [SerializeField] Sprite[] spirteFlashlight;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCondition();
    }
    void ChangeCondition()
    {
        if (flashlightWhite.activeSelf)
        {
            spriteRenderer.sprite = spirteFlashlight[0];
        }
        if (!flashlightWhite.activeSelf)
        {
            spriteRenderer.sprite = spirteFlashlight[1];
        }
        if (flashlightWhite.activeSelf)
        {
            spriteRenderer.sprite = spirteFlashlight[1];
        }
        if (!flashlightWhite.activeSelf)
        {
            spriteRenderer.sprite = spirteFlashlight[0];
        }
    }
}
