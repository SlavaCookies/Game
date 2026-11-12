using UnityEngine;

public class InventoryObject : MonoBehaviour, IScalableItem
{
    private string _nameObject;
    private Sprite _spriteObject;
    public string NameObject
    {
        get { return _nameObject; }
        set { _nameObject = value; }
    }
    public Sprite SpriteObject
    {
        get { return _spriteObject; }
        set { _spriteObject = value; }
    }
    public virtual Vector3 ScaleItem
    {
        get; set;
    }
    public virtual void AddToInventory() { }
    public void Initialize(string name, Sprite sprite)
    {
        _nameObject = name;
        _spriteObject = sprite;
    }
}
