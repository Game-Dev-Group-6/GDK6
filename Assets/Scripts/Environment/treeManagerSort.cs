using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeManagerSort : MonoBehaviour
{
    bool firstCount = false;
    [SerializeField] float countBefore, countAfter;
    enemyTrigger enemyTrigger;
    GameObject triggerGendoruwo;
    GameObject genderuwo;
    [SerializeField] GameObject[] tree;
    [SerializeField] HashSet<GameObject> sure = new HashSet<GameObject>();
    [SerializeField] List<GameObject> trees;
    [SerializeField] List<GameObject> treesInAreaGentayanganNotsSure;
    [SerializeField] List<GameObject> treesInAreaGentayanganForsSure;
    [SerializeField] public List<GameObject> treeRightEnemy;
    [SerializeField] public List<GameObject> treeLeftEnemy;
    // Start is called before the first frame update
    void Start()
    {
        triggerGendoruwo = GameObject.Find("RangeTriggerGendoruwo");
        genderuwo = GameObject.Find("Enemy_Gendoruwo");
        enemyTrigger = triggerGendoruwo.GetComponent<enemyTrigger>();


    }

    // Update is called once per frame
    void Update()
    {
        tree = GameObject.FindGameObjectsWithTag("Tree");
        trees = new List<GameObject>(tree);
        Sort();

        TreeInAreaGentayangan();
        treeLeftEnemy.Sort((b, a) => a.transform.position.x.CompareTo(b.transform.position.x));
        treeRightEnemy.Sort((b, a) => b.transform.position.x.CompareTo(a.transform.position.x));
    }

    void Sort()
    {
        if (treeRightEnemy.Count + treeLeftEnemy.Count >= treesInAreaGentayanganForsSure.Count)
        {
            treeRightEnemy.Clear();
            treeLeftEnemy.Clear();
        }
        countAfter = trees.Count;
        if (!firstCount)
        {
            countBefore = countAfter;
            firstCount = true;
        }

        if (countBefore > countAfter)
        {
            treesInAreaGentayanganNotsSure.Clear();
            sure.Clear();
            treesInAreaGentayanganForsSure.Clear();
            treeRightEnemy.Clear();
            treeLeftEnemy.Clear();
            countBefore = countAfter;
            Debug.Log("pohon berkurang");
        }
        if (countBefore < countAfter)
        {
            treesInAreaGentayanganNotsSure.Clear();
            sure.Clear();
            treesInAreaGentayanganForsSure.Clear();
            treeRightEnemy.Clear();
            treeLeftEnemy.Clear();
            countBefore = countAfter;
            Debug.Log("pohon bertambah");
        }
    }

    void TreeInAreaGentayangan()
    {
        foreach (GameObject treeIn in trees)// Mememasukkan semua tree yang ada di scene ke dalam > treesNotSure, kenapa notSure karena jumlah tree yang ada pada radius areaGentayangan belum diketahui
        {
            if (triggerGendoruwo != null)
            {
                if (treeIn.transform.position.x > triggerGendoruwo.transform.position.x - enemyTrigger.areaGentayangan && treeIn.transform.position.x < triggerGendoruwo.transform.position.x + enemyTrigger.areaGentayangan)
                {
                    if (treesInAreaGentayanganNotsSure.Count < trees.Count)
                    {
                        treesInAreaGentayanganNotsSure.Add(treeIn);
                    }
                }
            }
        }


        foreach (GameObject treeIn in treesInAreaGentayanganNotsSure)// memasukkan notSure ke Sure, dibagian ini GameObject yang memiliki nama sama, maka salah satu dari Gameobject tidak akan ditambahkan
        {
            if (!sure.Contains(treeIn))
            {
                sure.Add(treeIn);
                treesInAreaGentayanganForsSure.Add(treeIn);
            }
        }

        foreach (GameObject treeIn in treesInAreaGentayanganForsSure)// Menentukan pohon mana yang posisinya dikanan dan dikiri Enemy 
        {
            if (genderuwo != null)
            {
                if (treeIn.transform.position.x < genderuwo.transform.position.x)
                {
                    treeLeftEnemy.Add(treeIn);
                }
                else if (treeIn.transform.position.x > genderuwo.transform.position.x)
                {
                    treeRightEnemy.Add(treeIn);
                }
            }

        }
    }
}
