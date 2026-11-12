using UnityEngine;

public class Chest : MonoBehaviour
{
    public static Chest Instance { get; private set; }
    [SerializeField] private Sprite chestOpenSprite;
    private SpriteRenderer _spriteRenderer;
    private Transform _parentTransform;
    public SpriteRenderer spriteRenderer
    {
        get { return _spriteRenderer; }
        set { _spriteRenderer = value; }
    }
    public Transform ParentTransform
    {
        get { return _parentTransform; }
        set { _parentTransform = value; }
    }
    private void Awake()
    {
        Instance = this;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _parentTransform = gameObject.transform.parent.gameObject.transform;
    }
    public void ChangeSprite()
    {
        _spriteRenderer.sprite = chestOpenSprite;
    }
}
