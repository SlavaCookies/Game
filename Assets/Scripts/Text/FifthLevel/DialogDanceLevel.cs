using UnityEngine;
using System.Collections;

public class DialogDanceLevel : MonoBehaviour
{
    [SerializeField] private float leftX;
    [SerializeField] private float rightX;
    [SerializeField] private float downY;
    [SerializeField] private float upY;
    [SerializeField] private GameObject educationObject;
    [SerializeField] private Transform canvasTransform;
    private bool _isDialogStarted = false;
    private void Update()
    {
        Vector3 playerPosition = Player.Instance.gameObject.transform.localPosition;
        if (!_isDialogStarted && playerPosition.x > leftX && playerPosition.x < rightX &&
            playerPosition.y > downY && playerPosition.y < upY)
        {
            StartCoroutine(StartDialog());
            _isDialogStarted = true;
        }
    }

    private IEnumerator StartDialog()
    {
        DialogFunction.Instance.Dialog(0);
        yield return new WaitUntil(() => !DialogFunction.Instance.IsDialogActive);
        DialogFunction.Instance.Monolog(0);
        yield return new WaitUntil(() => !DialogFunction.Instance.IsThoughtActive);
        GameObject newEducationObject = Instantiate(educationObject, canvasTransform);
        gameObject.SetActive(false);
    }

    public bool IsDialogActive()
    {
        return DialogFunction.Instance.IsDialogActive;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftX, downY), new Vector2(rightX, downY));
        Gizmos.DrawLine(new Vector2(leftX, downY), new Vector2(leftX, upY));
        Gizmos.DrawLine(new Vector2(rightX, downY), new Vector2(rightX, upY));
        Gizmos.DrawLine(new Vector2(leftX, upY), new Vector2(rightX, upY));
        
    }
}
