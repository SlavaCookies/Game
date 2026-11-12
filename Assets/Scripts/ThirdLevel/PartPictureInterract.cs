using UnityEngine;

public class PartPictureInterract : MonoBehaviour, IInterract
{
    private bool _isRemove = false;

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void Interract()
    {

    }
    public bool IsRemove()
    {
        return _isRemove;
    }
}
