using UnityEngine;

public class UpdateMusicBackground : MonoBehaviour
{
    private void Awake()
    {
        if (PersistentMusic.Instance != null)
        {
            PersistentMusic.Instance.UpdateRoomKnowledge();
        }
    }
}
