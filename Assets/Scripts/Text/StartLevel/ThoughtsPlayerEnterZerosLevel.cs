using UnityEngine;

public class ThoughtsPlayerEnterZerosLevel : MonoBehaviour
{
    public static ThoughtsPlayerEnterZerosLevel Instance { get; private set; }
    [SerializeField] private float lineXPosition;
    [SerializeField] private float topYPosition;
    [SerializeField] private float bottomYPosition;
    private void Awake()
    {
        Instance = this;
    }
    private void FixedUpdate()
    {
        if (Player.Instance.gameObject.transform.localPosition.x >= lineXPosition &&
            LevelZeroManager.predScene == 0)
        {
            DialogFunction.Instance.Monolog(0);
            DestroyThisObject();
        }
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
