
using UnityEngine;

public class transition : MonoBehaviour
{
    [SerializeField] bool forOpening;
    Color newColor;
    [Range(0f, 0.5f)][SerializeField] float speedTransition;
    public bool reverse = false;
    public bool triggerTransition = false;


    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        newColor = GetComponent<UnityEngine.UI.Image>().color;
        newColor.a = 1;
        if (forOpening)
        {
            GetComponent<UnityEngine.UI.Image>().color = newColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!forOpening)
        {
            if (!triggerTransition)
            {
                ChangeAlphaOnAwake();
            }
            else if (triggerTransition)
            {
                ChangeAlphaOnLast();
            }
        }
        if (forOpening)
        {
            if (!triggerTransition)
            {
                ChangeAlphaOnLast();

            }
            else if (triggerTransition)
            {
                ChangeAlphaOnAwake();
            }
        }

    }
    public void ChangeAlphaOnAwake()//Open
    {
        if (newColor.a > 0 && !reverse)
        {
            newColor.a -= speedTransition;
            GetComponent<UnityEngine.UI.Image>().color = newColor;
            if (newColor.a <= 0)
            {
                reverse = true;
                if (!forOpening)
                {
                    gameObject.SetActive(false);
                }

            }
        }
    }
    public void ChangeAlphaOnLast()//Close
    {
        if (newColor.a < 1 && reverse)
        {
            newColor.a += speedTransition;
            GetComponent<UnityEngine.UI.Image>().color = newColor;
            if (newColor.a >= 1)
            {
                reverse = false;
            }
        }
    }

}
