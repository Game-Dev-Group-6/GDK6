using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactBag : MonoBehaviour
{
    InteractFlashLight flashLightIcon;
    // Start is called before the first frame update
    void Start()
    {
        flashLightIcon = transform.GetChild(0).gameObject.GetComponent<InteractFlashLight>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (flashLightIcon != null)
            {
                flashLightIcon.gameObject.SetActive(true);
                flashLightIcon.ChangePosition();
                flashLightIcon.GetComponent<BoxCollider2D>().enabled = true;
            }


            transform.localPosition += (Vector3)Vector2.up * 0.1f;
            transform.localScale += (Vector3)Vector2.one * 0.3f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (flashLightIcon != null)
            {
                flashLightIcon.ChangePositionNormal();
                flashLightIcon.GetComponent<BoxCollider2D>().enabled = false;
                flashLightIcon.gameObject.SetActive(false);
            }

            transform.localPosition -= (Vector3)Vector2.up * 0.1f;
            transform.localScale -= (Vector3)Vector2.one * 0.3f;
        }
    }


}
