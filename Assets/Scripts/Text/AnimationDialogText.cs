using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationDialogText : AnimationText
{
    public static AnimationDialogText Instance { get; private set; }
    [SerializeField] private Sprite playerSprite;
    [SerializeField] private Sprite npcSprite;
    private SpriteRenderer _spriteRenderer;
    private string[] _textsNPC = null;
    private int iPred = 0;
    private int jPred = 0;
    private bool _isEndTextsNPC = false;
    private string[] _currentTexts = { "" };
    private bool _isPlayerTalk = false;
    private bool _isPlayerStart = false;
    
    private IText _itext;
    
    public bool IsPlayerStart
    {
        get { return _isPlayerStart; }
        set { _isPlayerStart = value; }
    }
    public bool IsEndTextsNPC
    {                          
        get { return _isEndTextsNPC; }
        set { _isEndTextsNPC = value; }
    }
    private void Awake()
    {
        Instance = this;
        _spriteRenderer = TalkSprite.GetComponent<SpriteRenderer>();
        _itext = Itext as IText;
    }
 
    private void Update()
    {
        if ((!IsEndTextsPlayer || !_isEndTextsNPC) && IsTalk && PauseComplete())
        {
            if (_currentTexts[i] == " " && IsTalk)
            {
                ChangeTexts();   
                Debug.Log($"Индекс: {i}; Длина текстов: {_currentTexts.Length}; " +  
                    $"Предыдущий индекс: {iPred}; Кто говорит: {_isPlayerTalk}; Индекс j: {j}"); 
            }

            CurrentTime += Time.deltaTime;
            if (CurrentTime >= Interval)
            {
                CurrentTime = 0f;
                Text = CurrentText;
                if (j < _currentTexts[i].Length)
                {
                    CurrentText += _currentTexts[i][j];
                    j++;
                }
                else
                {
                    CurrentText = "";
                    j = 0;
                    if (i < _currentTexts.Length - 1)
                    {
                        i++;
                        IsPause = true;
                    }
                    else
                    {
                        if (_isPlayerTalk)
                        {
                            IsEndTextsPlayer = true;
                            _isEndTextsNPC = true;
                        }
                        else
                        {
                            _isEndTextsNPC = true;
                            IsEndTextsPlayer = true;
                        }
                        IsPause = true;
                        iPred = 0;
                        jPred = 0;
                    }
                }
            }
        }
        else
        {
            if (IsEndTextsPlayer && _isEndTextsNPC && PauseComplete())
            {
                CurrentTime = 0;
                CurrentText = "";
                i = 0;
                IsTalk = false;
            }
        }
        
    }

    public override void StartText()
    {
        IsTalk = true;
        int index = _itext.IndexDialogText;
        TextsPlayer = _itext.DialogTextsPlayer[index];
        _textsNPC = _itext.DialogTextsNPC[index];
        Text = "";
        
        if (_isPlayerStart)
        {
            _currentTexts = TextsPlayer;
            _isPlayerTalk = true;
            _spriteRenderer.sprite = playerSprite;
        }
        else
        {
            _currentTexts = _textsNPC;
            _isPlayerTalk = false;
            _spriteRenderer.sprite = npcSprite;
        }
    }

    private void ChangeTexts()
    {
        int iCurrent = 0;
        int jCurrent = 0;
        if (!_isPlayerTalk)
        {
            _currentTexts = TextsPlayer;
            iCurrent = iPred;
            jCurrent = jPred;
            iPred = ++i;
            jPred = j;
            i = iCurrent;
            j = jCurrent;
            _spriteRenderer.sprite = playerSprite;
            
        } else
        {
            _currentTexts = _textsNPC;
            iCurrent = iPred;
            jCurrent = jPred;
            iPred = ++i;
            jPred = j;
            i = iCurrent;
            j = jCurrent;
            _spriteRenderer.sprite = npcSprite;
        }
        _isPlayerTalk = !_isPlayerTalk;
    }
}
