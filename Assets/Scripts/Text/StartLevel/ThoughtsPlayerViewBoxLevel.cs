using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class ThoughtsPlayerViewBoxLevel : MonoBehaviour
{
    public static ThoughtsPlayerViewBoxLevel Instance { get; private set; }
    [SerializeField] private float lineXPosition;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float timeMovingCameraInLevel = 1f;
    [SerializeField] private float timeStayingCameraInLevel = 1f;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private float topYPosition;
    [SerializeField] private float bottomYPosition;
    private bool _isCameraStartMoveLevel = false;
    private Vector3 _startPosition;
    private Transform _followObject;
    private void Awake()
    {
        Instance = this;
        
    }
    private void FixedUpdate()
    {
        if (!_isCameraStartMoveLevel && Player.Instance.gameObject.transform.localPosition.x >= lineXPosition && 
            LevelZeroManager.predScene == 0)
        {
            _isCameraStartMoveLevel = true;
            StartCoroutine(CameraMove());
        }
    }
    private IEnumerator CameraMove()
    {
        DialogFunction.Instance.Monolog(1);
        Player.Instance.IsFreezePlayer = true;
        Player.Instance.IsRunning = false;
        _followObject = cinemachineCamera.Follow;
        cinemachineCamera.Follow = null;
        _startPosition = cinemachineCamera.gameObject.transform.localPosition;
        yield return CameraMoving(_startPosition, targetPosition);
        yield return new WaitForSeconds(timeStayingCameraInLevel);
        StartCoroutine(CameraMoving(targetPosition, _startPosition));
        yield return new WaitUntil(() => (cinemachineCamera.gameObject.transform.localPosition == _startPosition));
        cinemachineCamera.Follow = _followObject;
        Player.Instance.IsFreezePlayer = false;
        yield return new WaitUntil(() => !DialogFunction.Instance.IsThoughtActive);
        DestroyThisObject();    
    }
    
    private IEnumerator CameraMoving(Vector3 startPosition, Vector3 targetPosition)
    {
        float elapsed = 0f;
        while (elapsed <= timeMovingCameraInLevel)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / timeMovingCameraInLevel;
            cinemachineCamera.gameObject.transform.localPosition =
                Vector3.Lerp(startPosition, targetPosition, t);
            yield return null; 
        }
        cinemachineCamera.gameObject.transform.localPosition = targetPosition;
        
    }

    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.orange;
        Gizmos.DrawLine(new Vector2(lineXPosition, bottomYPosition), new Vector2(lineXPosition, topYPosition));
    }
}
