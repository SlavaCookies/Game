using UnityEngine;

public class ThoughtsReturnedThisLevelZero : MonoBehaviour
{
    public static ThoughtsReturnedThisLevelZero Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (LevelZeroManager.predScene == 7 && 
            PlayerVisual.Instance.IsAnimationSecondCompleteLevel)
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
