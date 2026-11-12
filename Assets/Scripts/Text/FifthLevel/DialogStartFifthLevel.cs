using UnityEngine;

public class DialogStartFifthLevel : MonoBehaviour
{
    public static DialogStartFifthLevel Instance { get; private set; }
    [SerializeField] private float needTimeWaiting = 10f;
    private float _currentTimeWaiting = 0f;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        Debug.Log(StartLevel.Instance.IsAnimationProccess);
        if (!StartLevel.Instance.IsAnimationProccess)
        {
            _currentTimeWaiting += Time.deltaTime;
            if (_currentTimeWaiting >= needTimeWaiting)
            {
                DialogFunction.Instance.Dialog(0);
                DestroyThisGameObject();
            }
        }
    }

    private void DestroyThisGameObject()
    {
        Destroy(gameObject);
    }
}
