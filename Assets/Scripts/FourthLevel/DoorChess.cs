using UnityEngine;

public class DoorChess : MonoBehaviour, IInterract
{
    public static DoorChess Instance { get; private set; }
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
        if (!_isUnlocked)
        {
            if (PlayerObject.Instance.NameObject == KeySO.nameObject) 
            {
                _isUnlocked = true;
                PlayerObject.Instance.ClearPlayerObjectItemInventory();
            }
        } else
        {
            LoadLevel.Instance.LoadScene();
        }
    }
    public bool IsRemove()
    {
        if (_isRemove)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        return _isRemove;
    } 
}
