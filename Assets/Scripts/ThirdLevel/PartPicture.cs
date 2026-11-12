using UnityEngine;

public class PartPicture : InventoryObject, IScalableItem
{
    [SerializeField] private Vector3 scaleItem;
    [SerializeField] private Vector3 positionItem;
    [SerializeField] private string nameObject;
    [SerializeField] private ButtonVision buttonVision;
    private SpriteRenderer _spriteRenderer;
    public override Vector3 ScaleItem
    {
        get { return scaleItem; }
        set { scaleItem = value; }
    }
    public Vector3 PositionItem
    {
        get { return positionItem; }
        set { positionItem = value; }
    }
    public ButtonVision ButtonVisionObject
    {
        get { return buttonVision; }
        set { buttonVision = value; }
    }
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SpriteObject = _spriteRenderer.sprite;
        NameObject = nameObject;
        
    }
    public override void AddToInventory()
    {
        BackpackOpen.Instance.InventoryObjects.Add(this);
        BackpackOpen.Instance.InventoryScalableObjects.Add(this);
    }
}
