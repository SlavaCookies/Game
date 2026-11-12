using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Rabbit : MonoBehaviour, IScalableItem
{
    public static Rabbit Instance { get; private set; }
    [SerializeField] private float x1Position;
    [SerializeField] private float x2Position;
    [SerializeField] private float y1Position;
    [SerializeField] private float y2Position;
    [SerializeField] private float yPositionUp = 1f;
    [SerializeField] private TakeRabbit takeRabbit;
    [SerializeField] private GameObject objectWithSpriteRenderer;
    [SerializeField] private Vector3 scaleItem;
    private const string _name = "Заяц";
    private bool _isHide = true;
    private SpriteRenderer _spriteRenderer;
    private MonoBehaviour _buttonVision;

    public string Name
    {
        get { return _name; }
    }
    public TakeRabbit TakeRabbitObject
    {
        get { return takeRabbit; }
        set { takeRabbit = value; }
    }
    public SpriteRenderer spriteRenderer
    {
        get { return _spriteRenderer; }
        set { _spriteRenderer = value; }
    }
    public MonoBehaviour ButtonVision
    {
        get { return _buttonVision; }
        set { _buttonVision = value; }
    }
    public Vector3 ScaleItem
    {
        get { return scaleItem; }
        set { scaleItem = value; }
    }
    private void Awake()
    {
        Instance = this;
        _spriteRenderer = objectWithSpriteRenderer.GetComponent<SpriteRenderer>();
        _buttonVision = GetComponent<ButtonVision>();
        _buttonVision.enabled = false;
    }

    private void Update()
    {
        if (_isHide && Player.Instance.transform.position.x > x1Position &&
            Player.Instance.transform.position.x < x2Position &&
            Player.Instance.transform.position.y > y2Position &&
            Player.Instance.transform.position.y < y1Position &&
            PlayerObject.Instance.NameObject == "Морковь") // &&
                                                           //Level1Texts.Instance.IndexThought == 4)
        {
            _isHide = false;
            Debug.Log("Onces");
            Vector2 newPosition = gameObject.transform.position;
            newPosition.y += yPositionUp;
            gameObject.transform.position = newPosition;
            takeRabbit.gameObject.SetActive(true);
            _buttonVision.enabled = true;
        }
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
