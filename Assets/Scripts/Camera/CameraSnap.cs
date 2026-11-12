using Unity.Cinemachine;
using UnityEngine;

[ExecuteAlways]
public class UltimatePixelPerfect : MonoBehaviour
{
    [Header("Основные настройки")]
    public int pixelsPerUnit = 16; // Должно совпадать с PPU спрайтов
    public bool snapCamera = true;
    public bool snapPlayer = true;

    [Header("Референсное разрешение")]
    public int referenceHeight = 1080; // Высота, под которую настраиваете

    [Header("Ссылки")]
    public CinemachineCamera virtualCamera;
    public Transform player;

    private Camera mainCamera;
    private float orthoSize;
    private float pixelSize;
    private int currentScreenHeight;

    void Start()
    {
        mainCamera = Camera.main;
        currentScreenHeight = Screen.height;

        SetupCamera();

        if (virtualCamera == null)
            virtualCamera = FindFirstObjectByType<CinemachineCamera>();

        if (player == null && virtualCamera != null)
            player = virtualCamera.Follow;
    }

    void SetupCamera()
    {
        if (mainCamera == null) return;

        // 1. Рассчитываем orthographic size для пиксельности
        // Это КРИТИЧЕСКИ важная формула
        orthoSize = (referenceHeight * 0.5f) / pixelsPerUnit;

        // 2. Рассчитываем реальный orthographic size для текущего экрана
        float scale = Mathf.Max(1, Mathf.Round((float)Screen.height / referenceHeight));
        mainCamera.orthographicSize = orthoSize / scale;

        // 3. Размер пикселя в юнитах
        pixelSize = 1f / (pixelsPerUnit * scale);

        Debug.Log($"Setup: PPU={pixelsPerUnit}, PixelSize={pixelSize}, OrthoSize={mainCamera.orthographicSize}");
    }

    void LateUpdate()
    {
        // Обновляем при изменении разрешения
        if (Screen.height != currentScreenHeight)
        {
            SetupCamera();
            currentScreenHeight = Screen.height;
        }

        // Снаппим камеру
        if (snapCamera && mainCamera != null)
        {
            SnapCamera();
        }

        // Снаппим игрока
        if (snapPlayer && player != null)
        {
            SnapTransform(player);
        }
    }

    void SnapCamera()
    {
        Vector3 camPos = mainCamera.transform.position;

        // СНАППИМ ТОЛЬКО если камера движется (следит за игроком)
        if (virtualCamera != null && virtualCamera.Follow != null)
        {
            // Получаем позицию цели
            Vector3 targetPos = virtualCamera.Follow.position;

            // Вычисляем смещение камеры относительно цели
            Vector3 offset = camPos - targetPos;

            // Снаппим позицию цели
            Vector3 snappedTarget = SnapPosition(targetPos);

            // Восстанавливаем позицию камеры со смещением
            Vector3 newCamPos = snappedTarget + offset;

            // Снаппим финальную позицию камеры
            newCamPos = SnapPosition(newCamPos);

            mainCamera.transform.position = newCamPos;
        }
        else
        {
            // Для статичной камеры
            mainCamera.transform.position = SnapPosition(camPos);
        }
    }

    void SnapTransform(Transform target)
    {
        if (target == null) return;

        Vector3 pos = target.position;
        target.position = SnapPosition(pos);
    }

    Vector3 SnapPosition(Vector3 position)
    {
        if (pixelSize <= 0) pixelSize = 1f / pixelsPerUnit;

        return new Vector3(
            Mathf.Round(position.x / pixelSize) * pixelSize,
            Mathf.Round(position.y / pixelSize) * pixelSize,
            position.z
        );
    }

    // Для отладки в редакторе
#if UNITY_EDITOR
    void OnValidate()
    {
        if (!Application.isPlaying && mainCamera == null)
            mainCamera = Camera.main;

        if (mainCamera != null)
            SetupCamera();
    }
#endif
}