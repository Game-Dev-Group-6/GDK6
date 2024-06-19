using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DelayChangeScene : MonoBehaviour
{
    public string sceneName; // Nama scene yang ingin di-load
    public float delay = 2f; // Delay dalam detik sebelum scene di-load

    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    // Coroutine untuk delay
    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay); // Tunggu selama delay
        SceneManager.LoadScene(0); // Load scene yang ditentukan
    }
}
