using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditsTrigger : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("ShowTrashInJalurPendakian"))
        {
            PlayerPrefs.SetString("ShowTrashInJalurPendakian", "");
        }
    }
    public string sceneName; // Nama scene yang ingin di-load
    public float delay = 2f; // Delay dalam detik sebelum scene di-load

    // Fungsi untuk memulai perubahan scene dengan delay
    public void StartChangeScene()
    {
        StartCoroutine(ChangeSceneWithDelay());
    }

    // Coroutine untuk delay
    private IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(delay); // Tunggu selama delay
        SceneManager.LoadScene(0); // Load scene yang ditentukan
    }
}
