using UnityEngine;

public class TextInformationObject : MonoBehaviour, IInterract
{
    public static TextInformationObject Instance { get; private set; }
    [SerializeField] private GameObject informationObject;
    [SerializeField] private Vector3 informationObjectPosition;
    [SerializeField] private Transform canvasTransform;
    private bool _isInformationObjectActive = false;
    private bool _isRemove = false;
    public bool IsInformationObjectActive
    {
        get { return _isInformationObjectActive; }
        set { _isInformationObjectActive = value; }
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
        if (!_isInformationObjectActive)
        {
            GameObject _newObject = Instantiate(informationObject, canvasTransform);
            _newObject.transform.localPosition = informationObjectPosition;
            _isInformationObjectActive = true;
        }   
    }

    public bool IsRemove()
    {
        return _isRemove;
    }
}
