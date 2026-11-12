using UnityEngine;

public class DiabledShadowObjectPlayerArea : MonoBehaviour
{
    private void Start()
    {
        if (LevelZeroManager.isTeleportFromSixthLevelToZero)
        {
            gameObject.SetActive(false);
        }
    }
}
