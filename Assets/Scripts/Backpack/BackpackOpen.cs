using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BackpackOpen : MonoBehaviour, IPointerClickHandler
{
    public static BackpackOpen Instance { get; private set; }
    [SerializeField] private Sprite inventorySprite;
    [SerializeField] private GameObject buttonTake;
    [SerializeField] private GameObject buttonExit;
    [SerializeField] private Vector3 vectorInventory;
    [SerializeField] private Vector2 inventoryColliderSize;
    [SerializeField] private float distanceInInventory = 1.3f;
    [SerializeField] private GameObject SelectObject;
    [SerializeField] private Vector3 scale;
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 objectScale;
    [SerializeField] private Vector3 objectScaleIsActiveScale;
    
    
    
    private SpriteRenderer _spriteRenderer;
    private Sprite _backpackSprite;
    private GameObject _newButtonTake;
    private GameObject _newButtonExit;
    private Vector3 _backpackPosition;
    private Vector2 _backpackColliderSize;
    private BoxCollider2D _boxCollider2D;
    private InventoryObject _selectedObject = null;
    private int _countItems = 0;
    private GameObject _selectObject = null;
    private int _maxSizeBackpack = 36;
    private List<InventoryObject> _inventoryObjects = new List<InventoryObject>();
    private List<GameObject> _inventoryViewObjects = new List<GameObject>();
    private List<IScalableItem> _inventoryScalableObjects = new List<IScalableItem>();
    private bool _isScaleActiveBackpack = false;
    private Vector3 _scalePred;
    private Vector3 _positionPred;
    
    public List<InventoryObject> InventoryObjects
    {
        get { return _inventoryObjects; }

        set { _inventoryObjects = value; }
    }

    public List<IScalableItem> InventoryScalableObjects
    {
        get { return _inventoryScalableObjects; }
        set { _inventoryScalableObjects = value; }
    }

    public InventoryObject SelectedObject
    {
        get { return _selectedObject; }
        set { _selectedObject = value; }
    }
    public Vector3 BackpackPosition
    {
        get { return _backpackPosition; }
        set { _backpackPosition = value; }
    }
    public bool IsScaleActiveBackpack
    {
        get { return _isScaleActiveBackpack; }
        set { _isScaleActiveBackpack = value; }
    }

    private void Awake()
    {
        Instance = this;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _backpackSprite = _spriteRenderer.sprite;
        _backpackPosition = gameObject.transform.localPosition;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _backpackColliderSize = _boxCollider2D.size;
        _positionPred = gameObject.transform.localPosition;
        _scalePred = gameObject.transform.localScale;
    }
    private void Update()
    {
        if (_isScaleActiveBackpack)
        {
            if (_spriteRenderer.sprite != _backpackSprite)
            {
                gameObject.transform.localPosition = position;
                gameObject.transform.localScale = scale;

                if (_selectObject != null)
                {
                    _selectObject.transform.localScale = objectScaleIsActiveScale;
                }
            }
        } else
        {
            if (_spriteRenderer.sprite != _backpackSprite)
            {
                gameObject.transform.localPosition = vectorInventory;
                gameObject.transform.localScale = _scalePred;
                if (_selectObject != null)
                {
                    _selectObject.transform.localScale = objectScale;
                }
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log(eventData.position);
            if (_spriteRenderer.sprite == _backpackSprite)
            {
                _spriteRenderer.sprite = inventorySprite;
                gameObject.transform.localPosition = vectorInventory;
                _boxCollider2D.size = inventoryColliderSize;
                _newButtonTake = Instantiate(buttonTake);
                _newButtonTake.transform.SetParent(gameObject.transform);
                _newButtonTake.transform.localPosition = new Vector3(-3.2f, -5f, 0f);
                _newButtonExit = Instantiate(buttonExit);
                _newButtonExit.transform.SetParent(gameObject.transform);
                _newButtonExit.transform.localPosition = new Vector3(3.2f, -5f, 0f);

                ViewAllObjects();
            }
            else
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
                Vector2 localPosition = transform.InverseTransformPoint(worldPosition);
                Debug.Log(localPosition);
                for (int i = 0; i < _maxSizeBackpack; ++i)
                {
                    int row = i % 6;
                    int col = i / 6;
                    int row2 = 0;
                    int col2 = (i + 6) / 6;
                    if ((i + 1) % 6 == 0)
                    {
                        row2 = (i + (col + 1)) % 7; // Для правых граничных слотов.
                        if (localPosition.x > (-3.91f + distanceInInventory * row) &&
                            localPosition.x < (-3.91f + distanceInInventory * row2) &&
                            localPosition.y < (3.91f - distanceInInventory * col) &&
                            localPosition.y > (3.91f - distanceInInventory * col2))
                        {
                            if (i < _inventoryObjects.Count)
                            {
                                _selectedObject = _inventoryObjects[i];
                                _selectedObject.ScaleItem = _inventoryScalableObjects[i].ScaleItem;
                            } else
                            {
                                _selectedObject = null;
                            }
                            if (_selectObject == null)
                            {
                                _selectObject = Instantiate(SelectObject);
                            }
                            _selectObject.transform.SetParent(gameObject.transform);
                            _selectObject.transform.localPosition =
                                new Vector2(-3.3f + distanceInInventory * row,
                                3.3f - distanceInInventory * col);
                        }
                    }
                    else
                    {
                        row2 = (i + 1) % 6;
                        if (localPosition.x > (-3.91f + distanceInInventory * row) &&
                        localPosition.x < (-3.91f + distanceInInventory * row2) &&
                        localPosition.y < (3.91f - distanceInInventory * col) &&
                        localPosition.y > (3.91f - distanceInInventory * col2))
                        {
                            if (i < _inventoryObjects.Count)
                            {
                                _selectedObject = _inventoryObjects[i];
                                _selectedObject.ScaleItem = _inventoryScalableObjects[i].ScaleItem;
                            } else
                            {
                                _selectedObject = null;
                            }
                            if (_selectObject == null)
                            {
                                _selectObject = Instantiate(SelectObject);
                            }
                            _selectObject.transform.SetParent(gameObject.transform);
                            _selectObject.transform.localPosition =
                                new Vector2(-3.3f + distanceInInventory * row,
                                3.3f - distanceInInventory * col);
                        }
                    }

                }
            }
        }
    }

    public void CloseBackpack()
    {
        DestroyAllObjectsInInventory();
        _spriteRenderer.sprite = _backpackSprite;
        gameObject.transform.localPosition = _backpackPosition;
        _boxCollider2D.size = _backpackColliderSize;
        Destroy(_newButtonTake);
        Destroy(_newButtonExit);
        if (_selectObject != null)
        {
            Destroy(_selectObject);
        }
    }
    private void ViewAllObjects()
    {

        for (int i = 0; i < _inventoryObjects.Count; ++i)
        {
            if (_inventoryObjects[i] != null)
            {
                Debug.Log(_inventoryScalableObjects[i] == null);
                Debug.Log(i);
                CreateEmptyObjectInInventory(_inventoryObjects[i].SpriteObject, i,
                _inventoryScalableObjects[i]);
            }
        }
    }

    private void CreateEmptyObjectInInventory(Sprite sprite, int i, IScalableItem scaleItem)
    {
        GameObject newObject = new GameObject($"InventoryItem{_countItems++}");
        newObject.transform.SetParent(gameObject.transform);

        newObject.transform.localPosition = new Vector3(-3.3f + distanceInInventory * (i % 6),
            3.3f - distanceInInventory * (i / 6));
        newObject.AddComponent<SpriteRenderer>();
        SpriteRenderer spriteRendererObject = newObject.GetComponent<SpriteRenderer>();
        spriteRendererObject.sprite = sprite;
        newObject.transform.localScale = scaleItem.ScaleItem;
        spriteRendererObject.sortingOrder = 19;
        newObject.AddComponent<BoxCollider2D>();
        newObject.GetComponent<BoxCollider2D>().isTrigger = true;
        _inventoryViewObjects.Add(newObject);


    }
    public InventoryObject GetItemFromInventory(string nameObject)
    {
        foreach (var item in InventoryObjects)
        {
            if (item.NameObject == nameObject)
            {
                return item;
            }
        }
        return null;
    }
    public void DeleteItemFromInventory(string name)
    {
        for (int i = 0; i < _inventoryObjects.Count; ++i)
        {
            if (_inventoryObjects[i].NameObject == name)
            {
                _inventoryObjects.RemoveAt(i);
                _inventoryScalableObjects.RemoveAt(i);
            }
        }
    }

    private void DestroyAllObjectsInInventory()
    {
        foreach (var objectInventory in _inventoryViewObjects)
        {
            Destroy(objectInventory);
        }
        _inventoryViewObjects.Clear();
    }
}
