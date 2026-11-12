using UnityEngine;

public class DialogFunction : MonoBehaviour
{
    [SerializeField] private GameObject dialogField;
    [SerializeField] private MonoBehaviour itext;
    [SerializeField] private Sprite playerThoughtSprite;
    [SerializeField] private GameObject spriteWhoTalkField;
    public static DialogFunction Instance { get; private set; }
    private bool _isThoughtActive = false;
    private bool _isDialogActive = false;
    private IText _itext;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        Instance = this;
        dialogField.SetActive(false);
        _itext = itext as IText;
        _spriteRenderer = spriteWhoTalkField.GetComponent<SpriteRenderer>();
    }
    public void Monolog(int index)
    {
        _isThoughtActive = true;
        _isDialogActive = false;
        dialogField.SetActive(true);
        _spriteRenderer.sprite = playerThoughtSprite;
        _itext.IndexThought = index;
        AnimationThoughtText.Instance.StartText();
        
    }
    
    public void Dialog(int index)
    {
        _isThoughtActive = false;
        _isDialogActive = true;
        dialogField.SetActive(true);
        Player.Instance.IsFreezePlayer = true;
        Player.Instance.IsRunning = false;
        _itext.IndexDialogText = index;
        if (_itext.WhoStartTalk[index] == "player")
        {
            AnimationDialogText.Instance.IsPlayerStart = true;
        } else
        {
            AnimationDialogText.Instance.IsPlayerStart = false;
        }
        AnimationDialogText.Instance.StartText();
    }

    private void Update()
    {
        if (!AnimationThoughtText.Instance.IsTalk && _isThoughtActive)
        {
            AnimationThoughtText.Instance.IsEndTextsPlayer = false;
            dialogField.SetActive(false);
            _isThoughtActive = false;
        }
        if (!AnimationDialogText.Instance.IsTalk && _isDialogActive)
        {
            AnimationDialogText.Instance.IsEndTextsPlayer = false;
            AnimationDialogText.Instance.IsEndTextsNPC = false;
            Player.Instance.IsFreezePlayer = false;    
            dialogField.SetActive(false);
            _isDialogActive = false;
        }
    }

    public bool IsThoughtActive
    {
        get { return _isThoughtActive; }
        set { _isThoughtActive = value; }
    }
    public bool IsDialogActive
    {
        get { return _isDialogActive; }
        set { _isDialogActive = value; }
    }



}
