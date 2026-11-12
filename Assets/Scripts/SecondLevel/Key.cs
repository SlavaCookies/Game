using UnityEngine;

public class Key : InventoryObject, IScalableItem
{
    [SerializeField] private Vector3 scaleItem;
    private SpriteRenderer _spriteRenderer;
    public override Vector3 ScaleItem
    {
        get { return scaleItem; }
        set { scaleItem = value; }
    }
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        SpriteObject = _spriteRenderer.sprite;
        NameObject = KeySO.nameObject;
    }
    public override void AddToInventory()
    {
        BackpackOpen.Instance.InventoryObjects.Add(this);
        BackpackOpen.Instance.InventoryScalableObjects.Add(this);
    }
}
