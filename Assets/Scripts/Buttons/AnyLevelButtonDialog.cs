using UnityEngine;

public class AnyLevelButtonDialog : MonoBehaviour, IButtonSpace
{
    public static AnyLevelButtonDialog Instance { get; private set; }
    [SerializeField] private MonoBehaviour idialog;
    private IConditionsDialog _idialog;
    private void Awake()
    {
        Instance = this;
        _idialog = idialog.GetComponent<IConditionsDialog>(); 
        gameObject.SetActive(false);
    }
    private void Start()
    {
        AddButtonInList();
    }
    private void Update()
    {
        
    }
    public void AddButtonInList()
    {
        GameInput.Instance.spaceButtons.Add(this);
    }
    
    public void StartDialog()
    {
        _idialog.Condition();
    }
    
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
