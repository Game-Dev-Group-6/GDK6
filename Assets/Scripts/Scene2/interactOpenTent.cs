using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class interactOpenTent : MonoBehaviour
{
    //----- START Control Intensity OpenTentLight -----//
    bool reverse = false;
    public bool firstInteract = false;
    [SerializeField] Light2D openTentLight;
    [SerializeField] eventTendOpen eventTendOpen;
    //----- END -----//
    [SerializeField] GameObject textOpenTent;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TentLight();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            firstInteract = true;
            Debug.Log("PlayerMasuk");
            textOpenTent.SetActive(true);
            textOpenTent.GetComponent<Animator>().SetBool("Enable", false);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            firstInteract = true;
            textOpenTent.SetActive(true);
            textOpenTent.GetComponent<Animator>().SetBool("Enable", false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            firstInteract = false;
            if (openTentLight != null)
            {
                openTentLight.intensity = 3;
            }

            textOpenTent.GetComponent<Animator>().SetBool("Enable", true);
        }
    }

    void TentLight()
    {
        if (eventTendOpen != null)
        {
            if (firstInteract && !eventTendOpen.eventTrue)
            {
                if (openTentLight != null)
                {
                    if (openTentLight.intensity <= 10 && !reverse)
                    {
                        openTentLight.intensity += 0.2f;
                        if (openTentLight.intensity >= 10)
                        {
                            reverse = true;
                        }
                    }
                    else if (openTentLight.intensity >= 0 && reverse)
                    {
                        openTentLight.intensity -= 0.2f;
                        if (openTentLight.intensity <= 0)
                        {
                            reverse = false;
                        }
                    }
                }
            }
        }
    }
}
