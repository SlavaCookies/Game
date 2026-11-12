using UnityEngine;

public class SpawnInformationObjectBeforeStart : MonoBehaviour
{
    [SerializeField] private GameObject informationObject;
    [SerializeField] private Transform canvasTransform;
    private bool _isObjectSpawned = false;
    GameObject newInformationObject;
    private void LateUpdate()
    {
        if (!_isObjectSpawned && !StartLevel.Instance.IsAnimationProccess &&
            LevelZeroManager.predScene == 0)
        {
            newInformationObject = Instantiate(informationObject, canvasTransform);
            _isObjectSpawned = true;
            Player.Instance.IsFreezePlayer = true;
            //Destroy(gameObject);
        }
    }
    
    
}
