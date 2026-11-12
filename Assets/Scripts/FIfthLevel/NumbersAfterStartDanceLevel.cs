using NUnit.Framework.Constraints;
using UnityEngine;


public class NumbersAfterStartDanceLevel : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float intervalBetweenNumbers = 1f;
    private static readonly int NextNumber = Animator.StringToHash(NextNumberString);
    private const string NextNumberString = "NextNumber";
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _currentTimeInterval = 0f;
    private bool _isStartAnimation = false;
    private int _numberSprite = 0;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (_isStartAnimation)
        {
            if (_numberSprite < 5)
            {
                _spriteRenderer.sprite = sprites[_numberSprite];
                _currentTimeInterval += Time.fixedDeltaTime;
                if (_currentTimeInterval >= intervalBetweenNumbers)
                {
                    _animator.SetTrigger(NextNumber);
                    _currentTimeInterval = 0f;
                    _numberSprite++;
                }
            } else
            {
                _isStartAnimation = false;
                _spriteRenderer.sprite = null;
                FifthLevel.Instance.StartSequence();
            }
        } else
        {
            _numberSprite = 0;
            _currentTimeInterval = 0f;
        }
    }
    public void NumbersAnimationStart()
    {
        _isStartAnimation = true;
        _spriteRenderer.sprite = sprites[_numberSprite];
        _animator.SetTrigger(NextNumber);
    }
}
