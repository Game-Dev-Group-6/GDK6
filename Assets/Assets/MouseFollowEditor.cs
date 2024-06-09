using Cinemachine;
using UnityEngine;

[ExecuteInEditMode]
public class CameraMouseFollow : MonoBehaviour
{
    Vector3 mousepos;
    CinemachineVirtualCamera cinemachineVirtualCamera;
    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        // Hanya berfungsi dalam mode edit, bukan saat game berjalan
        if (!Application.isPlaying)
        {
            HandleMouseInput();
        }
    }

    void HandleMouseInput()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousepos);
    }
}
