using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonE : MonoBehaviour, IButtonE
{
    [SerializeField] private InventoryObject objectToInventory;
    [SerializeField] private MonoBehaviour scaleItem;
    [SerializeField] private AudioClip pickupSound;
    private InventoryObject _inventoryObject;
    private bool _isActivated = false;
    private IScalableItem _scaleItem;
    private bool _isObjectAdded = false;
    private void Awake()
    {
        _scaleItem = scaleItem as IScalableItem;
    }
    private void Start()
    {
        _inventoryObject = new GameObject().AddComponent<InventoryObject>();
        _inventoryObject.Initialize(objectToInventory.NameObject,
            objectToInventory.SpriteObject);
        GameInput.Instance.EButtons.Add(this);
    }
    public bool IsActive()
    {
        if (gameObject == null)
        {
            Destroy(gameObject);
            return false;
        }
        else
        {
            return gameObject.activeSelf;
        }
    }
    public void AddToInventory()
    {
        Debug.Log("ObjectAdded");
        if (!_isObjectAdded) {
            BackpackOpen.Instance.InventoryObjects.Add(_inventoryObject);
            BackpackOpen.Instance.InventoryScalableObjects.Add(_scaleItem);
            _isActivated = true;
            _isObjectAdded = true;
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
        }
    }
    public bool GetIsActivated()
    {
        return _isActivated;
    }
    public void DestroyThisObjectButton()
    {
        Destroy(gameObject.transform.parent.gameObject, 0.2f);
    }
    
    
    
}
