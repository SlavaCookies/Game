using UnityEngine;

public class ThoughtsHowTakeGuardRabbit : MonoBehaviour
{
    public static ThoughtsHowTakeGuardRabbit Instance { get; private set; }
    [SerializeField] private float x1Position;
    [SerializeField] private float x2Position;
    [SerializeField] private float y1Position;
    [SerializeField] private float y2Position;
    [SerializeField] private float needTimeToThoughts = 1f;
    private float _currentTimeToThoughts;
    private void Awake()
    {
        Instance = this;
    }
    
    private void Update()
    {
        if (PlayerObject.Instance.NameObject != CarrotSO.carrotName && 
            PlayerObject.Instance.NameObject != RabbitSO.rabbitName &&
            Level1Texts.Instance.IndexThought == 2 &&
            Player.Instance.transform.position.x > x1Position &&
            Player.Instance.transform.position.x < x2Position &&
            Player.Instance.transform.position.y > y2Position &&
            Player.Instance.transform.position.y < y1Position)
        {
            _currentTimeToThoughts += Time.deltaTime;
        }
        if (_currentTimeToThoughts >= needTimeToThoughts)
        {
            DialogFunction.Instance.Monolog(3);
            DestroyThisObject();
        }
        if (PlayerObject.Instance.NameObject == RabbitSO.rabbitName)
        {
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
        Gizmos.DrawLine(new Vector2(x1Position, y1Position), new Vector2(x2Position, y1Position));
        Gizmos.DrawLine(new Vector2(x1Position, y1Position), new Vector2(x1Position, y2Position));
        Gizmos.DrawLine(new Vector2(x1Position, y2Position), new Vector2(x2Position, y2Position));
        Gizmos.DrawLine(new Vector2(x2Position, y1Position), new Vector2(x2Position, y2Position));
    }
}
