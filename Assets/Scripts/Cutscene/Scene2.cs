using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Scene2 : MonoBehaviour
{
    [SerializeField] PlayableDirector timeline1;

    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Scene1_Timeline") == 3)
        {
            PlayerPrefs.DeleteKey("Scene1_Timeline");
        }
        if (timeline1 != null)
        {
            if (PlayerPrefs.HasKey("Scene1_Timeline"))
            {
                timeline1.Play();
            }
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
