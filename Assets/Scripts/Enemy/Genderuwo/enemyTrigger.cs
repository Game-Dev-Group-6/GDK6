using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class enemyTrigger : MonoBehaviour
{
    private bool combat = false;
    public bool combatBegin = false;//saat kondisi combatBegin = true, maka semua radius trigger diabaikan
    private Color newColor;
    private delayTime delayTime;//Pakai Time.time
    private Animator animator;
    [SerializeField] private DialogueManagerV2 dialogueManagerV2;
    int i = 0;
    int j = 0;

    [SerializeField]
    [Header("Urutan: Value areGentayangan harus > areaPenampakan > areaCombat")]
    public float areaGentayangan;
    [SerializeField] private float areaPenampakan, areaCombat, speedTrigger;

    private GameObject graveYard;
    private Vector2 posPlayer;
    private Transform childrenObj;
    private bool gentayangan = false;

    // Start is called before the first frame update
    void Start()
    {
        delayTime = GetComponent<delayTime>();
        childrenObj = transform.GetChild(0);
        animator = childrenObj.GetComponent<Animator>();
        childrenObj.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        posPlayer = GameObject.FindWithTag("Player").transform.position;
        float distance = Vector2.Distance(gameObject.transform.position, posPlayer);
        if (distance <= areaGentayangan && distance > areaPenampakan && !combat)
        {

            Gentayangan();
        }
        else if (distance <= areaPenampakan && distance > areaCombat && !combat)
        {
            childrenObj.transform.localScale = Vector2.one * 1;
            animator.SetBool("gentayangan", false);
            childrenObj.GetComponent<SpriteRenderer>().flipX = true;
            Penampakan();
        }


        else if (distance <= areaCombat && childrenObj.GetComponent<enemyHealthBar>().currentHealth > 0 || combat)
        {
            if (!combatBegin)
            {
                //Menempatkan posisi Gunda seperti posisi dari parentnya, yaitu TriggerEnemy
                if (!combat)
                {
                    childrenObj.transform.position = new Vector2(transform.position.x, transform.position.y);
                    childrenObj.transform.localScale = Vector2.one * 1.5f;
                    combat = true;
                }
                // Mengatur Gunda Supaya dikembalikan ke keadaan semula
                childrenObj.GetComponent<Rigidbody2D>().gravityScale = 1f;
                childrenObj.GetComponent<BoxCollider2D>().enabled = true;
                newColor.a = 1;
                childrenObj.GetComponent<SpriteRenderer>().color = newColor;

                //Jika dialog selesai maka akan menampilkan GraveStone/BatuNisan
                if (dialogueManagerV2.countClickButton == dialogueManagerV2.countSentences)
                {
                    Debug.Log("ShowGraveYard");
                    ShowGraveYard();
                    dialogueManagerV2.countClickButton = 0;
                }
            }
        }
        if (gentayangan)
        {
            childrenObj.transform.position = Vector2.MoveTowards(childrenObj.transform.position, new Vector2(transform.position.x, childrenObj.transform.position.y), speedTrigger);
        }
    }

    void Gentayangan()
    {
        childrenObj.transform.localScale = Vector2.one * 3;

        if (i < 1)
        {
            childrenObj.transform.position = Vector3.left * (areaGentayangan + 50);
            childrenObj.GetComponent<SpriteRenderer>().flipX = false;
            i++;
        }
        animator.SetBool("gentayangan", true);
        if (delayTime.Delay(1f))
        {
            gentayangan = true;
        }

        if (childrenObj.transform.position.x == transform.position.x)
        {
            gentayangan = false;
        }
        Debug.Log("Gentayangan");
    }

    void Penampakan()
    {
        childrenObj.GetComponent<Rigidbody2D>().gravityScale = 0f;
        if (j < 1)
        {
            childrenObj.transform.position = new Vector2(transform.position.x - (areaPenampakan - 13f), GameObject.Find("Ground").transform.position.y + GameObject.Find("Ground").GetComponent<SpriteRenderer>().bounds.size.y + 1f);
            j++;
            Debug.Log("Penampakan");
        }
        newColor = childrenObj.GetComponent<SpriteRenderer>().color;
        newColor.a -= 0.001f;
        childrenObj.GetComponent<SpriteRenderer>().color = newColor;
        childrenObj.GetComponent<BoxCollider2D>().enabled = false;
    }

    void ShowGraveYard()
    {
        graveYard = transform.GetChild(1).gameObject;
        graveYard.transform.position = new Vector2(transform.position.x - areaGentayangan, graveYard.transform.position.y);
        switchCamera grave = graveYard.GetComponent<switchCamera>();
        if (!grave.backToPlayer)
        {
            grave.LookGraveyard();
        }
        graveYard.GetComponent<Animator>().SetBool("look", true);
        graveYard.GetComponent<PolygonCollider2D>().enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, areaGentayangan);
        Gizmos.DrawWireSphere(transform.position, areaPenampakan);
        Gizmos.DrawWireSphere(transform.position, areaCombat);
    }
}
