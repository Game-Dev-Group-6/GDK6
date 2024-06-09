using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToScene3 : MonoBehaviour
{
    public bool salah;
    bool trigger = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetInt("Scene2To3", trigger ? 1 : 0);

        if (other.tag == "Player")
        {

            SceneManager.LoadScene(8);
        }
    }
}
