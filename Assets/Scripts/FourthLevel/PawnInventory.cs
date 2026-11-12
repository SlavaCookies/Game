using UnityEngine;

public class PawnInventory : InventoryObject
{
    public static PawnInventory Instance { get; private set; }
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
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteObject = _spriteRenderer.sprite;
        NameObject = FiguresSO.namePawn;
    }
    public override void AddToInventory()
    {
        BackpackOpen.Instance.InventoryObjects.Add(this);
        BackpackOpen.Instance.InventoryScalableObjects.Add(this);
    }
}
