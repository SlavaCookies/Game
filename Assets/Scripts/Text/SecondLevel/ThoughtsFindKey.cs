using UnityEngine;

public class ThoughtsFindKey : MonoBehaviour
{
    public static ThoughtsFindKey Instance { get; private set; }
    [SerializeField] private float x1Position;
    [SerializeField] private float x2Position;
    [SerializeField] private float y1Position;
    [SerializeField] private float y2Position;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Player.Instance.transform.position.x < x1Position && 
            Player.Instance.transform.position.y < y1Position &&
            Player.Instance.transform.position.y > y2Position &&
            Player.Instance.transform.position.x > x2Position)
        {
            DialogFunction.Instance.Monolog(2);
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
        Gizmos.DrawLine(new Vector2(x1Position, y1Position), new Vector2(x1Position, y2Position));
        Gizmos.DrawLine(new Vector2(x1Position, y1Position), new Vector2(x2Position, y1Position));
        Gizmos.DrawLine(new Vector2(x1Position, y2Position), new Vector2(x2Position, y2Position));
        Gizmos.DrawLine(new Vector2(x2Position, y1Position), new Vector2(x2Position, y2Position));
    }
}
