using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posRecycle : MonoBehaviour
{
    // Referensi ke RectTransform
    [SerializeField] Camera _camera;
    [SerializeField]
    GameObject sampah;
    public RectTransform rectTransform;

    void Update()
    {
        // Dapatkan posisi lokal dari RectTransform
        Vector2 localPosition = rectTransform.anchoredPosition;

        // Konversi posisi lokal ke posisi dunia
        Vector3 worldPosition = rectTransform.TransformPoint(localPosition);

        // Konversi posisi dunia ke posisi layar
        transform.position = worldPosition;
        /*Debug.Log(Camera.main.ScreenToWorldPoint(transform.position));*/
        sampah.transform.position = _camera.ScreenToWorldPoint(transform.position);
        /*Debug.Log("Posisi layar (screen space) dari RectTransform: " + worldPosition);*/
    }
}
