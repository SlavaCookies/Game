using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoorAndInTower : MonoBehaviour, IInterract
{
    public static OpenDoorAndInTower Instance { get; private set; }
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
        LoadLevel.Instance.LoadScene();
    }

    public bool IsRemove()
    {
        return _isRemove;
    }
    private void DestroyThisObject() 
    {
        GameInput.Instance.FButtons.Remove(this);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        DestroyThisObject();
    } 
}
