using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxScrolling : MonoBehaviour
{
    public float scrollSpeed = 0.1f; // Kecepatan scroll background
    public GameObject[] backgroundLayers; // Array untuk menyimpan kelompok background per layer
    public float overlap = 1f; // Overlap untuk menutup sambungan

    private RectTransform[][] layerRects; // RectTransforms dari setiap layer
    private float[] layerWidths; // Lebar dari setiap layer

    void Start()
    {
        // Inisialisasi RectTransforms dan lebar dari setiap objek dalam setiap layer
        layerRects = new RectTransform[backgroundLayers.Length][];
        layerWidths = new float[backgroundLayers.Length];

        for (int i = 0; i < backgroundLayers.Length; i++)
        {
            RectTransform[] children = backgroundLayers[i].GetComponentsInChildren<RectTransform>();
            layerRects[i] = new RectTransform[children.Length - 1]; // -1 karena GetComponentsInChildren juga mengambil parentnya

            for (int j = 1; j < children.Length; j++)
            {
                layerRects[i][j - 1] = children[j];
                if (j == 1)
                {
                    layerWidths[i] = children[j].rect.width; // Asumsi semua objek dalam satu layer memiliki lebar yang sama
                }
            }
        }
    }

    void Update()
    {
        // Loop melalui setiap layer dan setiap objek dalam layer untuk scroll sesuai kecepatan yang telah ditentukan
        for (int i = 0; i < layerRects.Length; i++)
        {
            float layerSpeed = scrollSpeed * (i + 1);
            for (int j = 0; j < layerRects[i].Length; j++)
            {
                RectTransform rt = layerRects[i][j];
                rt.anchoredPosition += Vector2.left * layerSpeed * Time.deltaTime;

                // Jika background keluar dari layar, pindahkan ke posisi akhir dengan overlap
                if (rt.anchoredPosition.x <= -layerWidths[i])
                {
                    float rightmostPosition = GetRightmostPosition(i);
                    rt.anchoredPosition = new Vector2(rightmostPosition + layerWidths[i] - overlap, rt.anchoredPosition.y);
                }
            }
        }
    }

    // Mendapatkan posisi paling kanan dari layer
    private float GetRightmostPosition(int layerIndex)
    {
        float rightmostPosition = float.MinValue;
        for (int i = 0; i < layerRects[layerIndex].Length; i++)
        {
            if (layerRects[layerIndex][i].anchoredPosition.x > rightmostPosition)
            {
                rightmostPosition = layerRects[layerIndex][i].anchoredPosition.x;
            }
        }
        return rightmostPosition;
    }
}
