using UnityEngine;

public class DoorGallery : MonoBehaviour, IInterract
{
    public static DoorGallery Instance { get; private set; }
    private bool _isRemove = false;
    private bool _isUnlocked = false;
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
        if (PlayerObject.Instance.NameObject == KeySO.nameObject)
        {
            _isUnlocked = true;
            BackpackOpen.Instance.DeleteItemFromInventory(KeySO.nameObject);
            PlayerObject.Instance.ClearPlayerObjectItemInventory();
        } else if (_isUnlocked == true)
        {
            LoadLevel.Instance.LoadScene();
            _isRemove = true;
        }
    }
    public bool IsRemove()
    {
        return _isRemove;
    }
}
