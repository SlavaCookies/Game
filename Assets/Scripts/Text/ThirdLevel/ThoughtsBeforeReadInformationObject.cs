using UnityEngine;

public class ThoughtsBeforeReadInformation : MonoBehaviour
{
    public static ThoughtsBeforeReadInformation Instance { get; private set; }
    
    private bool _isActivatedInformationObject = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (InformationObject.Instance?.IsActive() == true)
        {
            _isActivatedInformationObject = true;
        }
        if (InformationObject.Instance?.IsActive() == false && _isActivatedInformationObject)
        {
            DialogFunction.Instance.Monolog(0);
            DestroyThisObject();
        }
    }
    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
