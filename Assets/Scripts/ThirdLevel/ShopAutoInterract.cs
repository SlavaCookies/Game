using UnityEngine;

public class ShopAutoInterract : MonoBehaviour, IInterract
{
    public static ShopAutoInterract Instance { get; private set; }
    [SerializeField] private PartPicture partPicture;
    [SerializeField] private Vector3 partPicturePosition;
    [SerializeField] private Transform mapTransform;
    private bool _isRemove = false;
    private void Awake()
    {
        Instance = this;
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
        if (PlayerObject.Instance.NameObject == CoinGallerySO.nameObject)
        {
            GameObject newObject = Instantiate(partPicture.gameObject, 
                mapTransform); 
            newObject.transform.localPosition = partPicturePosition;
            newObject.transform.localScale = new Vector3(1f, 1f, 1f);
            newObject.GetComponent<PartPicture>().ButtonVisionObject.DistanceToView = 1f;
            newObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = -2;
            BackpackOpen.Instance.DeleteItemFromInventory(PlayerObject.Instance.NameObject);
            PlayerObject.Instance.ClearPlayerObjectItemInventory();
            _isRemove = true;
        }
    }

    public bool IsRemove()
    {
        return _isRemove;
    }
}
