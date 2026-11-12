using UnityEngine;

public class ThoughtsBeforeSpawnKey : MonoBehaviour
{
    public static ThoughtsBeforeSpawnKey Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (NPCWithPictureInterract.Instance.IsKeySpawned)
        {
            DialogFunction.Instance.Monolog(3);
            DestroyThisObject();
        }
    }
    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
