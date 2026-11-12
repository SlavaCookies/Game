using UnityEngine;

public class CoinGallery : InventoryObject, IScalableItem
{
    public static CoinGallery Instance { get; private set; }
    [SerializeField] private Vector3 scaleItemCoin;
    private SpriteRenderer _spriteRenderer;
    public override Vector3 ScaleItem
    {
        get { return scaleItemCoin; }
        set { scaleItemCoin = value; }
    }
    private void Awake()
    {
        Instance = this;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SpriteObject = _spriteRenderer.sprite;
        NameObject = CoinGallerySO.nameObject;
    }
    public override void AddToInventory()
    {
        BackpackOpen.Instance.InventoryObjects.Add(this);
        BackpackOpen.Instance.InventoryScalableObjects.Add(this);
    }
}
