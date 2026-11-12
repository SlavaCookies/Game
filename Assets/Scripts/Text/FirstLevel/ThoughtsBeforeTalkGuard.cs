using UnityEngine;

public class ThoughtsBeforeTalkGuard : MonoBehaviour
{
    public static ThoughtsBeforeTalkGuard Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Level1Texts.Instance.IndexDialogText == 1 
            && !AnimationDialogText.Instance.IsTalk)
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
