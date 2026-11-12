using UnityEngine;
using Unity.Cinemachine;

public class SimpleCameraSnap : MonoBehaviour
{
    [SerializeField] private int pixelsPerUnit = 16;

    private Camera mainCamera;
    private float pixelSize;

    void Start()
    {
        mainCamera = Camera.main;
        pixelSize = 1f / pixelsPerUnit;
    }

    void LateUpdate()
    {
        if (mainCamera == null) return;

        // СНАППИНГ - главное что нужно для pixel perfect
        Vector3 pos = mainCamera.transform.position;
        pos.x = Mathf.Round(pos.x / pixelSize) * pixelSize;
        pos.y = Mathf.Round(pos.y / pixelSize) * pixelSize;
        mainCamera.transform.position = pos;
    }

    // Утилита для снаппинга других объектов
    public Vector3 GetSnappedPosition(Vector3 position)
    {
        return new Vector3(
            Mathf.Round(position.x / pixelSize) * pixelSize,
            Mathf.Round(position.y / pixelSize) * pixelSize,
            position.z
        );
    }
}
