using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite colorTile;
    [SerializeField] private float minX = 13f;
    [SerializeField] private float minY = 5f;
    [SerializeField] private float difference = 2f;
    [SerializeField] private Sprite colorRed;
    [SerializeField] private Sprite colorGreen;
    private Vector2 _indexes;
    private SpriteRenderer _spriteRenderer;
    private Sprite _mainSprite;
    
    public Vector2 Indexes
    {
        get { return _indexes; }
        set { _indexes = value; }
    }
    public SpriteRenderer spriteRenderer
    {
        get { return _spriteRenderer; }
        set { _spriteRenderer = value; }
    }
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _mainSprite = _spriteRenderer.sprite;
        _indexes = new Vector2((9 - ((gameObject.transform.localPosition.y - minY)) / difference),
            (gameObject.transform.localPosition.x - minX) / difference);
    }

    private void Start()
    {
        FifthLevel.Instance.AddTileToTiles(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        if (FifthLevel.Instance.IsLevelStart && _spriteRenderer.sprite != colorTile)
        {
            _spriteRenderer.sprite = colorTile;
            FifthLevel.Instance.AddTileToSequenceTilesAndCheckSequenceTiles(this);
        }
    }
    public void ResetColor()
    {
        _spriteRenderer.sprite = _mainSprite;
    }
    public void SetColor()
    {
        _spriteRenderer.sprite = colorTile;
    }
    public void SetColorRed()
    {
        _spriteRenderer.sprite = colorRed;
        Color color = _spriteRenderer.color;
        color.r = 255;
        color.g = 0;
        color.b = 0;
        color.a = 255;
    }
    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
    public void SetColorGreen()
    {
        _spriteRenderer.sprite = colorGreen;
        Color color = _spriteRenderer.color;
        color.r = 0;
        color.g = 255;
        color.b = 0;
        color.a = 255;
    }
}
