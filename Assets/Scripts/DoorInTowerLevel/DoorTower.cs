using UnityEngine;

public class DoorTower : MonoBehaviour
{
    public static DoorTower Instance { get; private set; }
    [SerializeField] private OpenDoorAndInTower openDoorAndInTower;
    private MonoBehaviour _buttonVision;
    private void Awake()
    {
        Instance = this;
        _buttonVision = GetComponent<ButtonVision>();
        _buttonVision.enabled = false;
    }
    private void Update()
    {
        if (openDoorAndInTower.gameObject.activeSelf)
        {
            _buttonVision.enabled = true;
        }
    }
}
