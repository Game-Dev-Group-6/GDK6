using UnityEngine;

public class triggerWithCursor : MonoBehaviour
{
    public GameObject targetObject;
    void Start()
    {
        // Pastikan target object dinonaktifkan di awal
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Target Object is not assigned!");
        }
    }

    void Update()
    {
        // 0 adalah tombol klik kiri
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform == transform)
                {
                    // Mengaktifkan objek target
                    if (targetObject != null)
                    {
                        Debug.Log("Objek terhit!");
                        targetObject.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("Objek tidak terhit!");
                }
            }
            else
            {
                Debug.Log("Raycast tidak mengenai apapun!");
            }
        }
    }
}
