using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    private void Awake() 
    {
        if(instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    
    public void NextLevel() 
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadScene(string sceneName) 
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        if (transitionAnim != null)
        {
            transitionAnim.SetTrigger("End");
            yield return new WaitForSeconds(1); // Sesuaikan dengan durasi animasi
        }
        else
        {
            Debug.LogWarning("transitionAnim is not assigned");
            yield return null;
        }

        SceneManager.LoadScene(levelIndex);

        if (transitionAnim != null)
        {
            transitionAnim.SetTrigger("Start");
        }
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        if (transitionAnim != null)
        {
            transitionAnim.SetTrigger("End");
            yield return new WaitForSeconds(1); // Sesuaikan dengan durasi animasi
        }
        else
        {
            Debug.LogWarning("transitionAnim is not assigned");
            yield return null;
        }

        SceneManager.LoadScene(sceneName);

        if (transitionAnim != null)
        {
            transitionAnim.SetTrigger("Start");
        }
    }
}
