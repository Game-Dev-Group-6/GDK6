using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class interactBag : MonoBehaviour
{
    InteractFlashLight flashLightIcon;
    [SerializeField] AudioClip[] audioClip;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        flashLightIcon = transform.GetChild(0).gameObject.GetComponent<InteractFlashLight>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (flashLightIcon != null && !PlayerPrefs.HasKey("HaveFlashlightWhite"))
            {
                flashLightIcon.gameObject.SetActive(true);
                flashLightIcon.ChangePosition();
                flashLightIcon.GetComponent<BoxCollider2D>().enabled = true;
            }

            BagSFX();
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

    void BagSFX()
    {
        if (audioSource != null)
        {
            audioSource.clip = audioClip[0];
            audioSource.Play();
        }

    }

}
