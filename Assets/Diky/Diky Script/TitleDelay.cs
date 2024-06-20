using UnityEngine;

public class TitleDelay : MonoBehaviour
{
    public GameObject textActivate;
    // Start is called before the first frame update
    void Start()
    {
        textActivate.SetActive(true);
    }

    public void AnimaTextActivate()
    {
        textActivate.SetActive(false);
    }
}
