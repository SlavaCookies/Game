using UnityEngine;

public class SpawnInformationObjectClose : MonoBehaviour, IInterract
{
    [SerializeField] private SpawnCodeInformationObject informationObject;
    private GameObject objectToDelete;
    private bool _isRemove = false;
    private bool _isRemoveObject = false;
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
        objectToDelete = GameObject.FindGameObjectWithTag("InformationObject");
        Debug.Log("Interract1");
        _isRemoveObject = true;
        informationObject.IsInformationObjectActive = false;
        gameObject.SetActive(false);
    }
    public bool IsRemove()
    {
        if (_isRemoveObject)
        {
            Destroy(objectToDelete.gameObject);
        }
        return _isRemove;
    }
}
