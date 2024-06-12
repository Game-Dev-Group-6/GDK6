using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class opening : MonoBehaviour
{

    [SerializeField] GameObject[] imagesOpening;
    [SerializeField] transition transition;
    [SerializeField] bool typeFinish = false;
    [SerializeField] int narratorIndex = 1;
    [SerializeField] int[] showSentences;
    [SerializeField] private float typingSpeed = 0.05f;
    [Header("Dialogue TMP Text")]
    [SerializeField] private TextMeshProUGUI narratorText;

    [Header("Continue Buttons")]
    [SerializeField] private GameObject narratorSkipButton;

    [Header("Click Next Audio")]
    AudioSource uIAudioSource;

    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] narratorSentences;
    private float delayAfterStart = 0.6f;
    int indexImage = 0;
    bool startInGame;
    [SerializeField] delayTime2 delayTime2;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Scene1_Timeline", 1);
        TriggerStartNarrator();
        uIAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && typeFinish)
        {
            TriggerNarrator();
        }
        ImageManager();
        if (startInGame)
        {
            if (delayTime2.Delay(3))
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    private void TriggerStartNarrator()
    {
        StartCoroutine(StartNarrator());
    }

    private IEnumerator StartNarrator()
    {
        yield return new WaitForSeconds(delayAfterStart);
        StartCoroutine(TypeNarrator());
    }
    public void TriggerNarrator()
    {
        narratorSkipButton.SetActive(false);
        typeFinish = false;

        if (narratorIndex >= 2 && narratorIndex < 6)
        {
            StartCoroutine(ContinueNarrator());
            transition.triggerTransition = false;
            narratorIndex++;
            indexImage++;
        }
        else if (narratorIndex == 6)
        {
            transition.triggerTransition = false;
            narratorText.text = "";
            startInGame = true;
            Debug.Log("LoadScene");
        }
        else
        {
            StartCoroutine(ContinueNarrator());
            narratorIndex++;
        }
    }
    private IEnumerator ContinueNarrator()
    {
        narratorText.text = "";
        yield return new WaitForSeconds(delayAfterStart);
        StartCoroutine(TypeNarrator());
    }
    private IEnumerator TypeNarrator()
    {
        int lenghtChar = 1;
        foreach (char letter in narratorSentences[narratorIndex - 1].ToCharArray())
        {
            if (uIAudioSource != null)
            {
                uIAudioSource.Play();
            }

            narratorText.text += letter;
            lenghtChar++;
            yield return new WaitForSeconds(typingSpeed);
        }
        if (lenghtChar >= narratorSentences[narratorIndex - 1].ToCharArray().Length)
        {
            narratorSkipButton.SetActive(true);
            typeFinish = true;
        }

    }

    void ImageManager()
    {
        if (narratorIndex >= 2 && narratorIndex <= 6 && typeFinish)
        {
            if (imagesOpening != null)
            {
                imagesOpening[indexImage].SetActive(true);
                transition.triggerTransition = true;
            }
        }

    }


}
