using UnityEngine;

public class ThoughtsBeforeTalkWithFroggy : MonoBehaviour
{
    public static ThoughtsBeforeTalkWithFroggy Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (FroggyConditions.Instance?.IsFirstDialogTalk == true && DialogFunction.Instance.IsDialogActive == false)
        {
            DialogFunction.Instance.Monolog(1);
            DestroyThisObject();
        }
    }
    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
