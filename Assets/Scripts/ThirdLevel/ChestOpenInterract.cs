using UnityEditor;
using UnityEngine;

public class ChestOpenInterract : MonoBehaviour, IInterract
{
    public static ChestOpenInterract Instance { get; private set; }
    [SerializeField] private GameObject chestCode;
    [SerializeField] private Transform canvasTransform;
    private bool _isRemove = false;
    private bool _isChestCodeActivated = false;
    public bool IsChestCodeActivated
    {
        get { return _isChestCodeActivated; }
        set { _isChestCodeActivated = value; }
    }

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
        if (!_isChestCodeActivated)
        {
            GameObject newObject = Instantiate(chestCode, canvasTransform);
            _isChestCodeActivated = true;
            Player.Instance.IsFreezePlayer = true;
            gameObject.SetActive(false);
        }
    }    

    public bool IsRemove()
    {
        return _isRemove;
    }
}
