using Unity.VisualScripting;
using UnityEngine;

public class InformationObject : MonoBehaviour, IInterract
{
    public static InformationObject Instance { get; private set; }
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
        if (Instance == null || Instance.gameObject == null)
        {
            return false;
        }
        return gameObject.activeSelf;
    }
    public void Interract()
    {
        _isRemove = true;
        TextInformationObject.Instance.IsInformationObjectActive = false;
        GameInput.Instance.FButtons.Remove(this);
        Debug.Log(GameInput.Instance.FButtons.Count);
        Destroy(gameObject);
    }
    
    public bool IsRemove()
    {
        if (_isRemove)
        {
            Destroy(gameObject);
        }
        return _isRemove;
    }    
    
    public void AddToFButtons()
    {
        GameInput.Instance.FButtons.Add(this);
    }
}
