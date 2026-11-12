using System;
using System.Collections;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVisual : MonoBehaviour
{
    public static PlayerVisual Instance { get; private set; }
    [SerializeField] private Player player;
    [SerializeField] private RuntimeAnimatorController animatorNewControllerStartLevel;
    [SerializeField] private RuntimeAnimatorController currentAnimatorController; 
    [SerializeField] private Vector3 playerPositionWhenReturnedLevel;
    [SerializeField] private GameObject shadowPlayer;

    private static readonly int Running = Animator.StringToHash(IsRunning);
    private static readonly int Flip = Animator.StringToHash(IsFlip);
    private static readonly int PortalActivate = Animator.StringToHash(IsPortalActivate);
    private static readonly int PortalActivateFlip = Animator.StringToHash(IsPortalActivateFlip);
    private static readonly int FirstLevel = Animator.StringToHash(IsFirstLevel);
    private static readonly int NameLevelHired = Animator.StringToHash(IsNameLevelAlreadyHired);
    
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private const string IsRunning = "IsRunning";
    private const string IsFlip = "IsFlip";
    private const string IsPortalActivate = "IsPortalActivate";
    private const string IsPortalActivateFlip = "IsPortalActivateFlip";
    private const string IsFirstLevel = "FirstLevel";
    private const string IsNameLevelAlreadyHired = "IsNameLevelAlreadyHired";
    private bool _isFlip = false;
    private bool _isFirstLevelActivate = false;
    private bool _isPlayerUnFreezed = false;
    Portal _portal;
    private bool _isAnimationTeleportFromSixthLevelToZero = false;
    private bool _isAnimationSecondCompleteLevel = false;
    
    public event EventHandler OnResetVisual;
    public SpriteRenderer SpriteRendererProperties
    {
        get { return _spriteRenderer; }
    } 
    public bool IsAnimationSecondCompleteLevel
    {
        get { return _isAnimationSecondCompleteLevel; }
        set { _isAnimationSecondCompleteLevel = value; }
    }
    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteRenderer.flipX = false;
        if (Portal.Instance != null)
        {
            _portal = Portal.Instance;
        }
        if (LevelZeroManager.isTeleportFromSixthLevelToZero)
        {
            _animator.runtimeAnimatorController = animatorNewControllerStartLevel;
            Player.Instance.gameObject.transform.localPosition = playerPositionWhenReturnedLevel;
            _spriteRenderer.enabled = false;
            shadowPlayer.SetActive(false);
        } else
        {
        }
    }
    void Update()
    {
        if (!LevelZeroManager.isTeleportFromSixthLevelToZero)
        {
            PlayerAnimationController();
        }
        else
        {
            if (!_isAnimationTeleportFromSixthLevelToZero)
            {
                PlayerAnimationControllerWithTeleport();
                _isAnimationTeleportFromSixthLevelToZero = true;
            }
        }   
    }
    private void PlayerAnimationController()
    {

        _animator.SetBool(Running, Player.Instance.IsRunning);
        if (_portal != null && (!LevelZeroManager.isTeleportFromSixthLevelToZero || 
            SceneManager.GetActiveScene().buildIndex == 7))
        {
            PortalActivatePlayer();
        }
        AdjustPlayerFacingDirections();
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            FirstLevelActivate();
        }
        else if (!StartLevel.Instance.gameObject.activeSelf && !_isPlayerUnFreezed &&
            SceneManager.GetActiveScene().buildIndex != 1)        {
            Player.Instance.IsFreezePlayer = false;
            _isPlayerUnFreezed = true;
        }
        Debug.Log(Player.Instance.IsFreezePlayer);
    }
    private void PlayerAnimationControllerWithTeleport()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(AnimationStartLevel());
        }
    }
    private IEnumerator AnimationStartLevel()
    {
        _portal.gameObject.SetActive(false);
        yield return new WaitUntil(() => !StartLevel.Instance.IsAnimationProccess);
        _portal.gameObject.SetActive(true);
        Portal.Instance.PortalActivate();
        _spriteRenderer.enabled = true;
        shadowPlayer.SetActive(true);
        _animator.SetBool(NameLevelHired, !StartLevel.Instance.IsAnimationProccess);
        yield return new WaitForSeconds(1);
        UpdateAnimatorController();
    }
    private void AdjustPlayerFacingDirections()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerScreenPosition = Player.Instance.GetPlayerScreenPosition();
        _isFlip = mousePos.x < playerScreenPosition.x;
        if (_isFlip)
        {
            _animator.SetBool(Flip, _isFlip);
        } else
        {
            _animator.SetBool(Flip, _isFlip);
        }
    }

    private void PortalActivatePlayer()
    {
        if (!_isFlip)
        {
            _animator.SetBool(PortalActivate, _portal.IsPortalActivated);
        }
        else
        {
            _animator.SetBool(PortalActivateFlip, _portal.IsPortalActivated && _isFlip);
        }
    }

    private void FirstLevelActivate()
    {
        if (!StartLevel.Instance.IsAnimationProccess && (_portal == null) && !_isFirstLevelActivate)
        {
            _animator.SetTrigger(FirstLevel);
            _isFirstLevelActivate = true;
            Player.Instance.IsFreezePlayer = true;
        }
    }
    
    public void LoadScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            LevelZeroManager.isTeleportFromSixthLevelToZero = true;
        }
        LoadLevel.Instance.LoadScene();
    }
    public void ResetVisual()
    {
        Player.Instance.SetTransform(gameObject.transform);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;
        OnResetVisual?.Invoke(this, EventArgs.Empty);
        Player.Instance.IsFreezePlayer = false;
    }

    public void PlayerVisualEnable()
    {
        _spriteRenderer.enabled = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void UpdateAnimatorController()
    {
        _animator.runtimeAnimatorController = currentAnimatorController;

        if (_portal != null)
        {
            _portal.gameObject.SetActive(false);
            Destroy(_portal.gameObject);
        }

        Player.Instance.IsFreezePlayer = false;

        // Сбрасываем все флаги
        _isFirstLevelActivate = false;
        _isPlayerUnFreezed = false;
        _isAnimationTeleportFromSixthLevelToZero = false;

        _animator.SetBool(Running, Player.Instance.IsRunning);

        Debug.Log("Контроллер переключен, флаги сброшены");
        _isAnimationSecondCompleteLevel = true;
        LevelZeroManager.isTeleportFromSixthLevelToZero = false;
    }


}
