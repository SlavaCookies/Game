using UnityEngine;

public class ThoughtsLabyrynthStart : MonoBehaviour
{
    public static ThoughtsLabyrynthStart Instance { get; private set; }
    [SerializeField] private float x1Position;
    [SerializeField] private float x2Position;
    [SerializeField] private float yPosition;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Player.Instance.transform.position.y > yPosition)
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
        Gizmos.DrawLine(new Vector2(x1Position, yPosition), new Vector2(x2Position, yPosition));
    }



































































    








































}
