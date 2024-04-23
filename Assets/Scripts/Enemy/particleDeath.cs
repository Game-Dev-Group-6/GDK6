using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleDeath : MonoBehaviour
{
    ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        PartcileStop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PartcilePlay();
        }
    }
    public void PartcilePlay()
    {
        particle.Play();
        Debug.Log("partcile");
    }
    public void PartcileStop()
    {
        particle.Stop();
    }
}
