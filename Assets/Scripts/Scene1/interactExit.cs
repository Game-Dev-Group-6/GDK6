using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class interactExit : MonoBehaviour
{


    [SerializeField]
    GameObject tendExit;
    Animator animator;
    bool firstInteract = false;
    bool reverse = false;
    public bool getInteractMouse;
    private Light2D LightTendExit;
    // Start is called before the first frame update
    void Awake()
    {

        animator = tendExit.GetComponent<Animator>();
        LightTendExit = transform.GetChild(0).GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstInteract)
        {
            if (LightTendExit != null)
            {
                if (LightTendExit.intensity <= 10 && !reverse)
                {
                    LightTendExit.intensity += 0.2f;
                    if (LightTendExit.intensity >= 10)
                    {
                        reverse = true;
                    }
                }
                else if (LightTendExit.intensity >= 0 && reverse)
                {
                    LightTendExit.intensity -= 0.2f;
                    if (LightTendExit.intensity <= 0)
                    {
                        reverse = false;
                    }
                }
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (animator != null)
            {
                animator.SetBool("TendExit", true);
                animator.SetBool("TendExit2", false);
            }
            getInteractMouse = true;
            transform.localPosition += (Vector3)Vector2.up * 0.2f;
            transform.localScale += (Vector3)Vector2.up * 0.2f;
            firstInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (animator != null)
            {
                animator.SetBool("TendExit", false);
                animator.SetBool("TendExit2", true);
            }
            getInteractMouse = false;
            transform.localPosition -= (Vector3)Vector2.up * 0.2f;
            transform.localScale -= (Vector3)Vector2.up * 0.2f;
            firstInteract = false;
            LightTendExit.intensity = 0f;
        }
    }
}
