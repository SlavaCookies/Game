using UnityEngine;

public class HireFigure : MonoBehaviour, IInterract
{
    public static HireFigure Instance { get; private set; }
    [SerializeField] private ButtonVision buttonVision;
    [SerializeField] private GameObject figure;
    private bool _isRemove = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameInput.Instance.FButtons.Add(this);
    }
    public bool IsActive()
    {
        if (Instance == null)
        {
            return false;
        }
        return gameObject.activeSelf;
    }
    public void Interract()
    {
        GameObject newFigure = Instantiate(figure);
        _isRemove = true;
    
    }
    public bool IsRemove()
    {
        if (_isRemove)
        {
            Destroy(gameObject);
        }
        return _isRemove;
    }
    public void ChangeButtonVisionDistance()
    {
        buttonVision.DistanceToView = 1f;
    }
}
