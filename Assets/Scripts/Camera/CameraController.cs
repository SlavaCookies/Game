using UnityEngine;

public class CameraFollowWithHardBounds : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Follow Settings")]
    [SerializeField] private float smoothTime = 0.1f; // Используем smoothTime вместо smoothSpeed
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    [Header("Hard Bounds")]
    [SerializeField] private float leftLimit = -10f;
    [SerializeField] private float rightLimit = 10f;
    [SerializeField] private float bottomLimit = -5f;
    [SerializeField] private float upperLimit = 5f;

    [Header("Camera Size")]
    [SerializeField] private bool accountForCameraSize = true;

    private Camera cam;
    private Vector3 velocity = Vector3.zero;
    private float cameraHalfWidth;
    private float cameraHalfHeight;

    void Start()
    {
        cam = GetComponent<Camera>();
        CalculateCameraBounds();
    }

    void CalculateCameraBounds()
    {
        if (cam != null && cam.orthographic)
        {
            cameraHalfHeight = cam.orthographicSize;
            cameraHalfWidth = cameraHalfHeight * cam.aspect;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 1. Рассчитываем ЦЕЛЕВУЮ позицию (куда должна смотреть камера)
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;

        // 2. ОГРАНИЧИВАЕМ целевую позицию границами
        targetPosition = ApplyHardBounds(targetPosition);

        // 3. Плавное движение К ОГРАНИЧЕННОЙ позиции
        Vector3 smoothedPosition = Vector3.SmoothDamp(
            transform.position,
            targetPosition, // Используем ОГРАНИЧЕННУЮ позицию!
            ref velocity,
            smoothTime
        );

        // 4. Финальное ограничение (на всякий случай)
        smoothedPosition = ClampFinalPosition(smoothedPosition);

        // 5. Применяем
        transform.position = smoothedPosition;
    }

    Vector3 ApplyHardBounds(Vector3 desiredPos)
    {
        float clampedX = desiredPos.x;
        float clampedY = desiredPos.y;

        if (accountForCameraSize)
        {
            // Учитываем размер камеры
            clampedX = Mathf.Clamp(clampedX,
                leftLimit + cameraHalfWidth,
                rightLimit - cameraHalfWidth);

            clampedY = Mathf.Clamp(clampedY,
                bottomLimit + cameraHalfHeight,
                upperLimit - cameraHalfHeight);

            // Если карта меньше камеры - центрируем
            if (leftLimit + cameraHalfWidth > rightLimit - cameraHalfWidth)
                clampedX = (leftLimit + rightLimit) / 2f;

            if (bottomLimit + cameraHalfHeight > upperLimit - cameraHalfHeight)
                clampedY = (bottomLimit + upperLimit) / 2f;
        }
        else
        {
            // Простые границы
            clampedX = Mathf.Clamp(clampedX, leftLimit, rightLimit);
            clampedY = Mathf.Clamp(clampedY, bottomLimit, upperLimit);
        }

        return new Vector3(clampedX, clampedY, desiredPos.z);
    }

    Vector3 ClampFinalPosition(Vector3 position)
    {
        // Дополнительная проверка
        if (accountForCameraSize)
        {
            position.x = Mathf.Clamp(position.x,
                leftLimit + cameraHalfWidth,
                rightLimit - cameraHalfWidth);
            position.y = Mathf.Clamp(position.y,
                bottomLimit + cameraHalfHeight,
                upperLimit - cameraHalfHeight);
        }
        else
        {
            position.x = Mathf.Clamp(position.x, leftLimit, rightLimit);
            position.y = Mathf.Clamp(position.y, bottomLimit, upperLimit);
        }

        return position;
    }

    public void SnapToTarget()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position + offset;
            targetPos.z = transform.position.z;
            transform.position = ApplyHardBounds(targetPos);
            velocity = Vector3.zero; // Сбрасываем скорость
        }
    }

    private void OnDrawGizmos()
    {
        // Границы карты
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));

        // Границы с учетом размера камеры (зеленым)
        if (accountForCameraSize && cam != null && cam.orthographic)
        {
            Gizmos.color = Color.green;

            float halfHeight = cam.orthographicSize;
            float halfWidth = halfHeight * cam.aspect;

            float innerLeft = leftLimit + halfWidth;
            float innerRight = rightLimit - halfWidth;
            float innerBottom = bottomLimit + halfHeight;
            float innerTop = upperLimit - halfHeight;

            if (innerLeft <= innerRight && innerBottom <= innerTop)
            {
                Gizmos.DrawLine(new Vector2(innerLeft, innerTop), new Vector2(innerRight, innerTop));
                Gizmos.DrawLine(new Vector2(innerLeft, innerBottom), new Vector2(innerRight, innerBottom));
                Gizmos.DrawLine(new Vector2(innerLeft, innerTop), new Vector2(innerLeft, innerBottom));
                Gizmos.DrawLine(new Vector2(innerRight, innerTop), new Vector2(innerRight, innerBottom));
            }
        }
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (cam == null)
            cam = GetComponent<Camera>();

        CalculateCameraBounds();
    }
#endif
}