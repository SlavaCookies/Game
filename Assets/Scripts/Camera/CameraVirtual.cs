// Добавьте этот скрипт к Virtual Camera или Follow-цели
using Unity.Cinemachine;
using UnityEngine;

public class PixelPerfectCinemachine : MonoBehaviour
{
    [SerializeField] private float pixelsPerUnit = 16f;
    [SerializeField] private CinemachineCamera virtualCamera;

    private void LateUpdate()
    {
        if (virtualCamera == null || virtualCamera.Follow == null) return;

        // Получаем позицию цели
        Vector3 targetPos = virtualCamera.Follow.position;

        // Снаппим к пиксельной сетке
        float pixelSize = 1f / pixelsPerUnit;
        targetPos.x = Mathf.Round(targetPos.x / pixelSize) * pixelSize;
        targetPos.y = Mathf.Round(targetPos.y / pixelSize) * pixelSize;

        // Применяем к виртуальной камере
        virtualCamera.transform.position = new Vector3(
            targetPos.x,
            targetPos.y,
            virtualCamera.transform.position.z
        );
    }
}