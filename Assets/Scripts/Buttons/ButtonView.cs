using JetBrains.Annotations;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonView : MonoBehaviour, IPointerClickHandler
{
    public static ButtonView Instance { get; private set; }
    [SerializeField] private CinemachineCamera cameraMain;
    [SerializeField] private Vector3 buttonPosition;
    [SerializeField] private Vector3 backpackPosition;
    [SerializeField] private Vector3 scaleButton;
    [SerializeField] private Vector3 scaleBackpack;
    [SerializeField] private Vector3 dialogViewPosition;
    [SerializeField] private Vector3 dialogViewScale;
    [SerializeField] private GameObject dialogView;
    [SerializeField] private Vector3 buttonQuestionPosition;
    [SerializeField] private Vector3 scaleButtonQuestion;
    [SerializeField] private Vector3 minimapPosition;
    [SerializeField] private Vector3 scaleMinimap;
    [SerializeField] private int orthographicSize = 10;
    private Vector3 _buttonPositionPred;
    private Vector3 _backpackPositionPred;
    private Vector3 _scaleButton;
    private Vector3 _scaleBackpack;
    private Vector3 _dialogViewPositionPred;
    private Vector3 _scaleDialogView;
    private Vector3 _buttonQuestionPositionPred;
    private Vector3 _scaleButtonQuestionPred;
    private Vector3 _minimapPositionPred;
    private Vector3 _scaleMinimapPred;
    private CinemachineConfiner2D _confiner;
    private bool _isActiveButton = false;
    public bool IsActiveButton
    {
        get { return _isActiveButton; }
        set { _isActiveButton = value; }
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _backpackPositionPred = BackpackOpen.Instance.gameObject.transform.localPosition;
        _buttonPositionPred = gameObject.transform.localPosition;
        _scaleButton = gameObject.transform.localScale;
        _scaleBackpack = BackpackOpen.Instance.gameObject.transform.localScale;
        _dialogViewPositionPred = dialogView.transform.localPosition;
        _scaleDialogView = dialogView.transform.localScale;
        if (ButtonQuestion.Instance != null)
        {
            _buttonQuestionPositionPred = ButtonQuestion.Instance.gameObject.transform.localPosition;
            _scaleButtonQuestionPred = ButtonQuestion.Instance.gameObject.transform.localScale;
        }
        _minimapPositionPred = Minimap.Instance.gameObject.transform.localPosition;
        _scaleMinimapPred = Minimap.Instance.gameObject.transform.localScale;
        _confiner = cameraMain.GetComponent<CinemachineConfiner2D>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ViewAction();
        }
    }

    public void ViewAction()
    {
        if (cameraMain.Lens.OrthographicSize == 5)
        {
            _isActiveButton = true;
            _confiner.enabled = false;
            cameraMain.Lens.OrthographicSize = orthographicSize;
            BackpackOpen.Instance.gameObject.transform.localPosition = backpackPosition;
            BackpackOpen.Instance.gameObject.transform.localScale = scaleBackpack;
            BackpackOpen.Instance.BackpackPosition = backpackPosition;
            BackpackOpen.Instance.IsScaleActiveBackpack = true;
            gameObject.transform.localPosition = buttonPosition;
            gameObject.transform.localScale = scaleButton;
            dialogView.transform.localPosition = dialogViewPosition;
            dialogView.transform.localScale = dialogViewScale;
            if (ButtonQuestion.Instance != null)
            {
                ButtonQuestion.Instance.gameObject.transform.localPosition = buttonQuestionPosition;
                ButtonQuestion.Instance.gameObject.transform.localScale = scaleButtonQuestion;
            }
            Minimap.Instance.gameObject.transform.localPosition = minimapPosition;
            Minimap.Instance.gameObject.transform.localScale = scaleMinimap;
        }
        else
        {
            _isActiveButton = false;
            _confiner.enabled = true;
            cameraMain.Lens.OrthographicSize = 5;
            BackpackOpen.Instance.gameObject.transform.localPosition = _backpackPositionPred;
            BackpackOpen.Instance.gameObject.transform.localScale = _scaleBackpack;
            BackpackOpen.Instance.BackpackPosition = _backpackPositionPred;
            BackpackOpen.Instance.IsScaleActiveBackpack = false;
            gameObject.transform.localPosition = _buttonPositionPred;
            gameObject.transform.localScale = _scaleButton;
            dialogView.transform.localPosition = _dialogViewPositionPred;
            dialogView.transform.localScale = _scaleDialogView;
            if (ButtonQuestion.Instance != null)
            {
                ButtonQuestion.Instance.gameObject.transform.localPosition = _buttonQuestionPositionPred;
                ButtonQuestion.Instance.gameObject.transform.localScale = _scaleButtonQuestionPred;
            }
            Minimap.Instance.gameObject.transform.localPosition = _minimapPositionPred;
            Minimap.Instance.gameObject.transform.localScale = _scaleMinimapPred;
        }
    }
}
