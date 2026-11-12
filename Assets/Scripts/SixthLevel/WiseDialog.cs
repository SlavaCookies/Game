using System.Collections;
using UnityEngine;

public class WiseDialog : MonoBehaviour, IButtonSpace
{
    public static WiseDialog Instance { get; private set; }
    [SerializeField] private Vector3 positionBeforeDialog;
    [SerializeField] private QuestionsLevel questions;
    [SerializeField] private QuestionsGame questionsGame;
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private Sprite spriteUpdateMinimap;
    
    private bool _isWiseDialogFirstStarted = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        AddButtonInList();
    }
    public void AddButtonInList()
    {
        GameInput.Instance.spaceButtons.Add(this);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void StartDialog()
    {
        if (!_isWiseDialogFirstStarted)
        {
            StartCoroutine(Dialog());
            _isWiseDialogFirstStarted = true;
            Minimap.Instance.spriteRenderer.sprite = spriteUpdateMinimap;
        } else
        {
            StartCoroutine(StartGame());
        }
    }
    public void DialogBeforeCompleteGameWise()
    {
        StartCoroutine(StartDialogBeforeGameWise());
    }
    private IEnumerator StartDialogBeforeGameWise()
    {
        Debug.Log($"До Диалога: {DialogFunction.Instance.IsDialogActive}");
        DialogFunction.Instance.Dialog(2);
        Debug.Log($"Диалог: {DialogFunction.Instance.IsDialogActive}");
        yield return new WaitUntil(() => !DialogFunction.Instance.IsDialogActive);
        Debug.Log($"После Диалога: {DialogFunction.Instance.IsDialogActive}");
        DialogFunction.Instance.Monolog(0);
        Debug.Log($"Монолог: {DialogFunction.Instance.IsThoughtActive}");
        yield return new WaitUntil(() => !DialogFunction.Instance.IsThoughtActive);
        Debug.Log($"После Монолога: {DialogFunction.Instance.IsThoughtActive}");
        Portal.Instance.PortalActivate();
    }
    private IEnumerator Dialog()
    {
        DialogFunction.Instance.Dialog(0);
        yield return new WaitUntil(() => !DialogFunction.Instance.IsDialogActive);
        gameObject.transform.parent.gameObject.transform.position = positionBeforeDialog;
    }

    private IEnumerator StartGame()
    {
        DialogFunction.Instance.Dialog(1);
        yield return new WaitUntil(() => !DialogFunction.Instance.IsDialogActive);
        GameObject newQuestionsGame = Instantiate(questionsGame.gameObject, canvasTransform);
        QuestionsGame _questionsGame;
        if (!newQuestionsGame.TryGetComponent<QuestionsGame>(out _questionsGame))
        {
            newQuestionsGame.AddComponent<QuestionsGame>();
            _questionsGame = newQuestionsGame.GetComponent<QuestionsGame>();
        }
        if (_questionsGame.enabled == false)
        {
            _questionsGame.enabled = true;
        }
        _questionsGame.minimap = Minimap.Instance;
        _questionsGame.backpackOpen = BackpackOpen.Instance;
        _questionsGame.questions = questions;
        GameInput.Instance.spaceButtons.Clear();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
