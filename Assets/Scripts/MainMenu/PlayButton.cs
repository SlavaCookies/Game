using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void LoadScene()
    {
        LevelZeroManager.isTeleportFromSixthLevelToZero = false;
        LevelZeroManager.BoxPosition = LevelZeroManager.BoxPositionReset;
        SceneManager.LoadScene(1);
    }
}
