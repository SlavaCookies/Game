using UnityEngine;

public class DoorDance : MonoBehaviour, IInterract
{
    private bool _isRemove = false;
    private bool _isUnlocked = false;
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

    private void Start()
    {
        GameInput.Instance.FButtons.Add(this);
    }
}
