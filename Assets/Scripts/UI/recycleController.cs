using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI.Table;

public class recycleController : MonoBehaviour
{
    [SerializeField]
    GameObject posRecycle, trash;
    bool moveToRecycle = false;
    [SerializeField]
    GameObject particle;
    Animator animator;
    void Start()
    {
        particle.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Y))
        {
            moveToRecycle = true;
        }
       
        TrashMoveToRecycle();



    }
    public void RecycleOn()
    {
        moveToRecycle = true;
    }
    public void RecycleOff()
    {
        animator.SetBool("RecycleOn", false);
        particle.SetActive(false);
    }

    public void ParticleOn()
    {
        particle.SetActive(true);
    }
    void TrashMoveToRecycle()
    {
        if (moveToRecycle)
        {
            trash.transform.position = Vector2.MoveTowards(trash.transform.position, posRecycle.transform.position, 0.1f);
            if(trash.transform.position == posRecycle.transform.position)
            {
                trash.transform.position = posRecycle.transform.position;
                animator.SetBool("RecycleOn", true);
            }
                
        }
    }
}
