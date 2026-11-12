using UnityEngine;

public class SpawnCodeInformationObject : MonoBehaviour, IInterract
{
    [SerializeField] private Sprite spriteInformation;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private GameObject objectToCreateInScene;
    [SerializeField] private SpawnInformationObjectClose objectClose;
    private bool _isRemove = false;
    private bool _isInformationObjectActive = false;
    public bool IsInformationObjectActive
    {
        get { return _isInformationObjectActive; }
        set { _isInformationObjectActive = value; }
    }
    private void Start()
    {
        GameInput.Instance.FButtons.Add(this);
        objectClose.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (_isRemove)
        {
            GameInput.Instance.FButtons.Remove(this);
            Destroy(gameObject);
        }
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void Interract()
    {
        if (!_isInformationObjectActive)
        {
            Debug.Log("Interract");
            GameObject newObject = Instantiate(objectToCreateInScene, cameraTransform);
            newObject.transform.localPosition = new Vector3(0f, 0f, 0f);
            newObject.GetComponent<SpriteRenderer>().sprite = spriteInformation;
            _isInformationObjectActive = true;
            objectClose.gameObject.SetActive(true);
        }
    }
    public bool IsRemove()
    {
        return _isRemove;
    }
}
