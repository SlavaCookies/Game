using UnityEngine;

public class DoorLabyrynth : MonoBehaviour, IInterract
{
    public static DoorLabyrynth Instance { get; private set; }
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
            InventoryObject key = BackpackOpen.Instance.GetItemFromInventory(KeySO.nameObject);
            PlayerObject.Instance.NameObject = " ";
            PlayerObject.Instance.SpriteRenderer.sprite = null;
            if (key != null)
            {
                BackpackOpen.Instance.InventoryObjects.Remove(key);
            }
            _isUnlocked = true;
        } else if (!_isUnlocked)
        {
            DialogFunction.Instance.Monolog(1);
        } else
        {
            LoadLevel.Instance.LoadScene();
        }
    }
    public bool IsRemove()
    {
        return _isRemove;
    }
}


