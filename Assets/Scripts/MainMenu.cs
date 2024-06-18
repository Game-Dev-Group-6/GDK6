using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float delay = 2f; // Waktu penundaan dalam detik

    private void Start()
    {

    }

    public void StartGame()
    {
        Debug.Log("StartGame called"); // Tambahkan debug log
        StartCoroutine(DelayedStartGame());
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame called"); // Tambahkan debug log
        StartCoroutine(DelayedQuitGame());
    }

    private IEnumerator DelayedStartGame()
    {
        // Tunggu selama 'delay' detik
        yield return new WaitForSeconds(delay);

        // Pindah ke scene yang dituju
        Debug.Log("Loading scene: SampleScene"); // Tambahkan debug log
        SceneManager.LoadScene("Scene_2_Bintang_Raya");
    }

    private IEnumerator DelayedQuitGame()
    {
        // Mainkan efek suara klik
        AudioManager.Instance.PlaySfx(0);

        // Tunggu selama 'delay' detik
        yield return new WaitForSeconds(delay);

        // Keluar dari game
        Debug.Log("Quitting game"); // Tambahkan debug log
        Application.Quit();
    }
}
