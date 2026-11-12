using JetBrains.Annotations;
using UnityEngine;
[SelectionBase]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D _rb;
    private Vector2 _inputVector;
    private bool _isRunning;
    private float _minMovingSpeed = 0.1f;
    private bool _isFreezePlayer = false;

    private Camera _mainCamera;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
        }
    }

    public float MovingSpeed 
    { 
        get
        {
            return movingSpeed;
        }
    }

    public bool IsFreezePlayer
    {
        get
        {
            return _isFreezePlayer;
        }
        set
        {
            _isFreezePlayer = value;
        }
    }

    public Camera MainCamera
    {
        get
        {
            return _mainCamera;
        }
    }
    private void Awake()
    {
        Instance = this;
        _rb = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    
    }
    
    // Update is called once per frame
    private void Update()
    {
        _inputVector = GameInput.Instance.GetMovementVector();
    }
    
    private void FixedUpdate()
    {
        if (!_isFreezePlayer)
        {
            MovePlayer();
        }
        else
        {
            _isRunning = false;
        }
    }
    
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = _mainCamera.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
    private void MovePlayer()
    {
        if (Mathf.Abs(_inputVector.x) > _minMovingSpeed || Mathf.Abs(_inputVector.y) > _minMovingSpeed)
        {
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }
        _rb.MovePosition(_rb.position + _inputVector * (movingSpeed * Time.fixedDeltaTime));
    }
    public void SetTransform(Transform transform)
    {
        gameObject.transform.position = transform.position;
    }

    private void DisabledMovement()
    {
        GameInput.Instance.DisabledMovement();
    }
}
