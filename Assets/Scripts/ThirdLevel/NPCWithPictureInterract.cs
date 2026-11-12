using UnityEngine;

public class NPCWithPictureInterract : MonoBehaviour, IInterract
{
    public static NPCWithPictureInterract Instance { get; private set; }
    [SerializeField] private Vector3 keyPosition;
    [SerializeField] private Key key;
    [SerializeField] private PartPicture partPicture1;
    [SerializeField] private PartPicture partPicture2;
    [SerializeField] private PartPicture partPicture3;
    [SerializeField] private PartPicture partPicture4;
    [SerializeField] private PartPicture partPicture5;
    [SerializeField] private Transform mapTransform;
    private bool _isRemove = false;
    private int _countParts = 0;
    private bool _isPartPicture1Spawned = false;
    private bool _isPartPicture2Spawned = false;
    private bool _isPartPicture3Spawned = false;
    private bool _isPartPicture4Spawned = false;
    private bool _isPartPicture5Spawned = false;
    private bool _isKeySpawned = false;
    public bool IsKeySpawned
    {
        get { return _isKeySpawned; }
        set { _isKeySpawned = value; }
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        GameInput.Instance.FButtons.Add(this);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void Interract()
    {
        if (PlayerObject.Instance.NameObject == PartPictureSO.nameObject1)
        {
            if (!_isPartPicture1Spawned)
            {
                CreatePartPictureObject(partPicture1);
                _isPartPicture1Spawned = true;
                BackpackOpen.Instance.DeleteItemFromInventory(PlayerObject.Instance.NameObject);
                PlayerObject.Instance.ClearPlayerObjectItemInventory();
            }
        } else if (PlayerObject.Instance.NameObject == PartPictureSO.nameObject2)
        {
            if (!_isPartPicture2Spawned)
            {
                CreatePartPictureObject(partPicture2);
                _isPartPicture2Spawned = true;
                BackpackOpen.Instance.DeleteItemFromInventory(PlayerObject.Instance.NameObject);
                PlayerObject.Instance.ClearPlayerObjectItemInventory();
            }
        } else if (PlayerObject.Instance.NameObject == PartPictureSO.nameObject3)
        {
            if (!_isPartPicture3Spawned)
            {
                CreatePartPictureObject(partPicture3);
                _isPartPicture3Spawned = true;
                BackpackOpen.Instance.DeleteItemFromInventory(PlayerObject.Instance.NameObject);
                PlayerObject.Instance.ClearPlayerObjectItemInventory();
            }
        } else if (PlayerObject.Instance.NameObject == PartPictureSO.nameObject4)
        {
            if (!_isPartPicture4Spawned)
            {
                CreatePartPictureObject(partPicture4);
                _isPartPicture4Spawned = true;
                BackpackOpen.Instance.DeleteItemFromInventory(PlayerObject.Instance.NameObject);
                PlayerObject.Instance.ClearPlayerObjectItemInventory();
            }
        } else if (PlayerObject.Instance.NameObject == PartPictureSO.nameObject5)
        {
            if (!_isPartPicture5Spawned)
            {
                CreatePartPictureObject(partPicture5);
                _isPartPicture5Spawned = true;
                BackpackOpen.Instance.DeleteItemFromInventory(PlayerObject.Instance.NameObject);
                PlayerObject.Instance.ClearPlayerObjectItemInventory();
            }
        }

    }
    public bool IsRemove()
    {
        return _isRemove;
    }
    private void CreatePartPictureObject(PartPicture partPicture)
    {
        GameObject newObject = Instantiate(partPicture.gameObject, mapTransform);
        newObject.transform.position = partPicture.PositionItem;
        newObject.transform.localScale = new Vector3(1, 1, 1);
        _countParts++;
        //partPicture.ButtonVisionObject.DistanceToView = 0f;
        newObject.GetComponentInChildren<PartPicture>().ButtonVisionObject.DistanceToView = 0f;
        newObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = 5;
        if (_countParts == 5)
        {
            SpawnKey();
        }
    }
    private void SpawnKey()
    {
        GameObject newObject = Instantiate(key.gameObject);
        _isKeySpawned = true;
    }
}
