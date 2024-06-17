using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathParticleManager : MonoBehaviour
{
    [SerializeField] GameObject pocica;
    bool onePlay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PosPartcile();
    }
    void PosPartcile()
    {
        if (pocica != null)
        {
            transform.position = onePlay ? transform.position : pocica.transform.position;
            if (pocica.GetComponent<healthManager>().deathPartcile)
            {
                if (!onePlay)
                {
                    GetComponent<ParticleSystem>().Play();
                    onePlay = true;

                }
            }
        }
    }
}
