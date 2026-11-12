using UnityEngine;

public class DisableObjectsInLevelZero : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject greenArea;

    private void Start()
    {
        if (LevelZeroManager.isTeleportFromSixthLevelToZero)
        {
            box.transform.localPosition = LevelZeroManager.BoxPosition;
            greenArea.SetActive(false);
        }
    }
}
