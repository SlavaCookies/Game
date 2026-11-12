using System.Runtime.CompilerServices;
using UnityEngine;

public class TakeRabbit : MonoBehaviour, IInterract
{
    public static TakeRabbit Instance { get; private set; }
    [SerializeField] private GameObject rabbitVisual; 
    private SpriteRenderer _spriteRenderer;
    private Rabbit _rabbit;
    private bool _isRemove = false;
    public SpriteRenderer spriteRenderer
    {
        get { return _spriteRenderer; }
        set { _spriteRenderer = value; }
    }
    private void Awake()
    {
        Instance = this;
        _spriteRenderer = rabbitVisual.GetComponent<SpriteRenderer>();
        _rabbit = GetComponentInParent<Rabbit>();
    }
    private void Start()
    {
        GameInput.Instance.FButtons.Add(this);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void Interract()
    {
        string namePlayerObject = PlayerObject.Instance.NameObject;
        InventoryObject inventoryObject = BackpackOpen.Instance.GetItemFromInventory(namePlayerObject);
        PlayerObject.Instance.SpriteRenderer.sprite = _spriteRenderer.sprite;
        PlayerObject.Instance.NameObject = _rabbit.Name;
        PlayerObject.Instance.gameObject.transform.localScale = _rabbit.ScaleItem;
        if (inventoryObject != null)
        {
            BackpackOpen.Instance.InventoryObjects.Remove(inventoryObject);
        }
        DisableThisObject();
    }
    public bool IsRemove()
    {
        return _isRemove;
    }
    
    private void DisableThisObject()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    
    private void DestroyThisObject()
    {
        GameInput.Instance.FButtons.Remove(this);
        Destroy(gameObject);
    }
    
    private void OnDestroy()
    {
        DestroyThisObject();
    }
}
