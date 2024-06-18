using UnityEngine;

public class deathParticleManager : MonoBehaviour
{
    [SerializeField] GameObject pocica;
    bool onePlay;

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
