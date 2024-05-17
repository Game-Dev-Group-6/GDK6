using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlashlightButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject arrowImage; // Referensi ke Image panah
    public AudioSource hoverAudioSource; // Referensi ke komponen AudioSource untuk hover sound

    void Start()
    {
        if (arrowImage != null)
        {
            arrowImage.SetActive(false); // Pastikan panah awalnya tidak terlihat
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (arrowImage != null)
        {
            arrowImage.SetActive(true); // Tampilkan panah saat kursor masuk ke tulisan "Start"
        }

        if (hoverAudioSource != null)
        {
            hoverAudioSource.Play(); // Mainkan efek suara saat kursor masuk ke tulisan "Start"
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (arrowImage != null)
        {
            arrowImage.SetActive(false); // Sembunyikan panah saat kursor keluar dari tulisan "Start"
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Implementasikan logika untuk memulai permainan atau berpindah ke menu lain di sini
        Debug.Log("Button Terklik!"); // test button
    }
}
