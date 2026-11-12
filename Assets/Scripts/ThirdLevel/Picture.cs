using UnityEngine;

public class Picture : InventoryObject, IScalableItem
{
    public static Picture Instance { get; private set; }
    [SerializeField] private Vector3 scaleItem;
    private SpriteRenderer _spriteRenderer;
    public override Vector3 ScaleItem
    {
        get { return scaleItem; }
        set { scaleItem = value; }
    }
    private void Awake()
    {
        Instance = this;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SpriteObject = _spriteRenderer.sprite;
        NameObject = PictureSO.nameObject;
    }
    
    public override void AddToInventory()
    {
        BackpackOpen.Instance.InventoryObjects.Add(this);
        BackpackOpen.Instance.InventoryScalableObjects.Add(this);
    }
}
