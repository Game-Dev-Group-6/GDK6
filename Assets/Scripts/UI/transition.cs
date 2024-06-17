
using Cinemachine;
using UnityEngine;

public class transition : MonoBehaviour
{
    [SerializeField] bool transitionPoci, eventPoci, eventReverse;
    [SerializeField] bool forOpening;
    Color newColor;
    [Range(0f, 0.5f)][SerializeField] float speedTransition;
    public bool reverse = false;
    public bool triggerTransition = false;


    delayTime2 delayTime2;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        delayTime2 = GetComponent<delayTime2>();
        newColor = GetComponent<UnityEngine.UI.Image>().color;
        if (transitionPoci)
        {
            newColor.a = 0;
        }
        else if (!transitionPoci)
        {
            newColor.a = 1;
        }

        if (forOpening)
        {
            GetComponent<UnityEngine.UI.Image>().color = newColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!forOpening && !transitionPoci)
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
        if (transitionPoci)
        {
            ChangeAlphaOnLast();
            if (!reverse)
            {
                GameObject.FindWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 5f;
                if (delayTime2.Delay(2.5f))
                {
                    eventReverse = true;
                }
                if (eventReverse)
                {
                    ChangeAlphaOnAwake();
                }
            }
            if (eventPoci)
            {
                gameObject.SetActive(false);
                FindAnyObjectByType<pocicaCombatManager>().eventCameraShake = true;
            }
        }

    }
    public void ChangeAlphaOnAwake()//Open >> Gelap ke Terang(Transparan)
    {
        if (newColor.a > 0 && !reverse)
        {
            newColor.a -= speedTransition;
            GetComponent<UnityEngine.UI.Image>().color = newColor;
            if (newColor.a <= 0)
            {
                reverse = true;
                eventPoci = true;
                if (!forOpening)
                {
                    gameObject.SetActive(false);
                }

            }
        }
    }
    public void ChangeAlphaOnLast()//Close >> Terang(Transparan) ke Gelap
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
