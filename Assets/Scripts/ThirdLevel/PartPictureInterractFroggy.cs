using UnityEngine;

public class PartPictureInterractFroggy : MonoBehaviour, IButtonE
{
    public static PartPictureInterractFroggy Instance { get; private set; }
    [SerializeField] private ButtonVision buttonVision;
    [SerializeField] private InventoryObject inventoryObjectFroggy;
    [SerializeField] private MonoBehaviour scaleItemFroggy;
    [SerializeField] private AudioClip pickupSound;
    private bool _isFirstInterract = false;
    private InventoryObject _inventoryObject;
    private IScalableItem _scaleItem;
    private bool _isActivated = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _inventoryObject = new GameObject().AddComponent<InventoryObject>();
        _inventoryObject.Initialize(inventoryObjectFroggy.NameObject,
            inventoryObjectFroggy.SpriteObject);
        _scaleItem = scaleItemFroggy as IScalableItem;
        GameInput.Instance.EButtons.Add(this);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void AddToInventory()
    {
        if (!_isFirstInterract)
        {
            _isFirstInterract = true;
            DialogFunction.Instance.Dialog(0);
            gameObject.SetActive(false);
            buttonVision.DistanceToView = 0f;
            FroggyConditions.Instance.ChangeButtonVisionView();
            FroggyConditions.Instance.IsFirstDialogTalk = true;
        } else
        {
            BackpackOpen.Instance.InventoryObjects.Add(_inventoryObject);
            BackpackOpen.Instance.InventoryScalableObjects.Add(_scaleItem);
            _isActivated = true;
            AudioSource.PlayClipAtPoint(pickupSound, gameObject.transform.position);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    public bool GetIsActivated()
    {
        return _isActivated;
    }

    public void ChangeButtonVision()
    {
        buttonVision.DistanceToView = 1f;
        gameObject.SetActive(true);
    }


    public void DestroyThisObjectButton()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
