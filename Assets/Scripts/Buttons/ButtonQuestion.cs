using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonQuestion : MonoBehaviour, IPointerClickHandler
{
    public static ButtonQuestion Instance { get; private set; }
    [SerializeField] GameObject figureInformation;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Vector3 scale;
    [SerializeField] private Vector3 scaleIsScaleActive;
    private GameObject _newObject;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (BackpackOpen.Instance.IsScaleActiveBackpack)
        {
            if (_newObject != null)
            {
                _newObject.transform.localScale = scaleIsScaleActive;
            }
        }
        else
        {
            if (_newObject != null)
            {
                _newObject.transform.localScale = scale;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Player.Instance.IsFreezePlayer = true;
            _newObject = Instantiate(figureInformation, parentTransform);
        }
    }
}
