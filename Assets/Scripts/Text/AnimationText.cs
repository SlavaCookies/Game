using TMPro;
using UnityEngine;

public class AnimationText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float interval = 1f;
    [SerializeField] private float pause = 2f;
    [SerializeField] private GameObject talkSprite;
    [SerializeField] private MonoBehaviour itext;
    private float _currentTime = 0f;
    private float _currentPause = 0f;
    private string _currentText = "";
    private bool _isTalk = false;
    private string[] _textsPlayer = null;
    private bool _isPause = false;
    private bool _isEndTextsPlayer = false;
    public int i = 0;
    public int j = 0;
    private IText _itext;


    public float CurrentTime
    {
        get { return _currentTime; }
        set { _currentTime = value; }
    }
    public float CurrentPause
    {
        get { return _currentPause; }
        set { _currentPause = value; }
    }
    public string CurrentText
    {
        get { return _currentText; }
        set { _currentText = value; }
    }
    public bool IsTalk
    {
        get { return _isTalk; }
        set { _isTalk = value; }
    }
    public string[] TextsPlayer
    {
        get { return _textsPlayer; }
        set { _textsPlayer = value; }
    }
    public bool IsPause
    {
        get { return _isPause; }
        set { _isPause = value; }
    }
    public bool IsEndTextsPlayer
    {
        get { return _isEndTextsPlayer; }
        set { _isEndTextsPlayer = value; }
    }

    public string Text
    {
        get { return text.text; }
        set { text.text = value; }
    }

    public float Interval
    {
        get { return interval; }
        set { interval = value; }
    }
    public float Pause
    {
        get { return pause; }
        set { pause = value; }
    }
    public GameObject TalkSprite
    {
        get { return talkSprite; }
        set { talkSprite = value; }
    }
    public MonoBehaviour Itext
    {
        get { return itext; }
        set { itext = value; }
    }
    public virtual void StartText()
    {
    }
    
    public virtual void StartText(string[] texts)
    {
        
    }
    
    public virtual bool PauseComplete()
    {
        if (_isPause)
        {
            _currentPause += Time.deltaTime;
            if (_currentPause >= pause)
            {
                _isPause = false;
                _currentPause = 0f;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
}
