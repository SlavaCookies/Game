using UnityEngine;

public class ThoughtsBeforeViewObject : MonoBehaviour
{
    public static ThoughtsBeforeViewObject Instance { get; private set; }
    private bool _isInformationObjectViewed = false;
    private SpawnCodeInformationObject[] _informationObjects;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _informationObjects = FindObjectsByType<SpawnCodeInformationObject>(
            FindObjectsSortMode.None);
    }
    private void Update()
    {
        for (int i = 0; i < _informationObjects.Length; ++i)
        {
            if (_informationObjects[i].IsInformationObjectActive)
            {
                _isInformationObjectViewed = true;
            }
        }
        bool isAllInformationObjectsNotActive = true;
        for (int i = 0; i < _informationObjects.Length; ++i)
        {
            if (_informationObjects[i].IsInformationObjectActive)
            {
                isAllInformationObjectsNotActive = false;
            }
        }
        if (isAllInformationObjectsNotActive && _isInformationObjectViewed)
        {
            DialogFunction.Instance.Monolog(2);
            DestroyThisObject();
        }
    }
    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
