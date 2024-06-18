using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    // untuk input game objek
    public GameObject inputObject;
    public GameObject inputObject2;
    void Update() 
    {
        // Memberikan input key escape untuk pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Game objek aktif
            inputObject.SetActive(true);
            inputObject2.SetActive(false);

            // Memanggil fungsi
            PauseGame();
        }
    }
    void PauseGame() 
    {
        // Mengatur waktu game menjadi 0 agar game berhenti
        Time.timeScale = 0f;
    }

    void ResumeGame() 
    {
        // Mengatur waktu game menjadi 1 agar game jalan seperti semula
        Time.timeScale = 1f;
    }

    // Memberi parameter untuk input nama scene
    void QuitGame(string sceneName) 
    {
        // Mengatur waktu game menjadi 1 agar game jalan seperti semula
        Time.timeScale = 1f;

        // Load scene game
        SceneManager.LoadScene(sceneName);
    }
}
