using UnityEngine;

public class CodeChestClosedButton : MonoBehaviour, IInterract
{
    public static CodeChestClosedButton Instance { get; private set; }
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
        ChestOpenInterract.Instance.gameObject.SetActive(true);
        ChestOpenInterract.Instance.IsChestCodeActivated = false;
        _isRemove = true;
        Player.Instance.IsFreezePlayer = false;
        gameObject.SetActive(false);
    }
    public bool IsRemove()
    {
        if (_isRemove)
        {
            Destroy(gameObject.transform.parent.gameObject);


        }
        Debug.Log($"IsRemove: {_isRemove}");
        return _isRemove;
    }
}
