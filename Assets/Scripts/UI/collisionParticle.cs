using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionParticle : MonoBehaviour
{
    trashFloat trashFloat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        trashFloat =  FindAnyObjectByType<trashFloat>();
        trashFloat.fallDawn = true;
        Debug.Log(other.name);
    }
}