using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GoSecondScene : MonoBehaviour
{
    [SerializeField] private GreenArea greenArea;
    private BoxCollider2D _boxCollider2D;
    private Vector2 _inputVector;
    private Rigidbody2D _rb;
    private Orientation _orientation; 
    private Orientation _predOrientation = Orientation.Idle;
    private Vector2 _boxCollider2DSize;
    private PolygonCollider2D _polygonCollider2D;
    private bool _isPolygonCollider2DActivate = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2DSize = _boxCollider2D.size;
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        gameObject.transform.position = LevelZeroManager.BoxPosition;
    }

    private void Update()
    {
        _inputVector = GameInput.Instance.GetMovementVector();
        if (!Player.Instance.IsRunning)
        {
            _boxCollider2D.size = new Vector2(_boxCollider2DSize.x * 0.5f,
                _boxCollider2DSize.y * 0.5f);
        } else
        {
            _boxCollider2D.size = _boxCollider2DSize;
        }
    }

    private enum Orientation { 
        Idle,
        Left,
        Right,
        Down,
        Up,
        UpLeft,
        UpRight,
        DownLeft,
        DownlRight
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!LevelZeroManager.isTeleportFromSixthLevelToZero)
        {
            if (!greenArea.IsBoxInAreaProperty)
            {
                if (!_isPolygonCollider2DActivate)
                {
                    UnFreezeObject();
                }
                if (collision.transform.TryGetComponent(out Player player))
                {
                    if (_inputVector.x > 0 && _inputVector.y == 0)
                    {
                        _orientation = Orientation.Right;
                    }
                    else if (_inputVector.x < 0 && _inputVector.y == 0)
                    {
                        _orientation = Orientation.Left;
                    }
                    else if (_inputVector.y > 0 && _inputVector.x == 0)
                    {
                        _orientation = Orientation.Up;
                    }
                    else if (_inputVector.y < 0 && _inputVector.x == 0)
                    {
                        _orientation = Orientation.Down;
                    }
                    if (_boxCollider2D.IsTouching(collision))
                    {
                        if (CheckOrientation())
                        {
                            UnFreezeObject();
                            MoveObjects.Instance.MoveObject(_inputVector, _rb);
                            _predOrientation = _orientation;
                        }
                        else
                        {
                            FreezeObject();
                            ActivatePolygonCollider2D();
                        }
                    }
                    else if (_polygonCollider2D.IsTouching(collision))
                    {
                        if (((_predOrientation == Orientation.Right || _predOrientation == Orientation.Left)
                            && (_orientation == Orientation.Right || _orientation == Orientation.Left)) ||
                            ((_predOrientation == Orientation.Up || _predOrientation == Orientation.Down)
                            && (_orientation == Orientation.Up || _orientation == Orientation.Down)))
                        {
                            DeactivatePolygonCollider2D();
                            _predOrientation = _orientation;
                            UnFreezeObject();
                        }
                    }
                }
                else
                {
                    DeactivatePolygonCollider2D();
                    _predOrientation = _orientation;
                }
            }
            else
            {
                FreezeObject();
                Portal.Instance.PortalActivate();
                Player.Instance.IsFreezePlayer = true;
                Player.Instance.IsRunning = false;
                LevelZeroManager.BoxPosition = gameObject.transform.localPosition;

            }
        } else
        {
            _polygonCollider2D.enabled = true;
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    
    private void FreezeObject()
    {
        _boxCollider2D.isTrigger = false;
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void UnFreezeObject()
    {
        _boxCollider2D.isTrigger = true;
        _rb.constraints = RigidbodyConstraints2D.None;
    }

    private bool CheckOrientation()
    {
        if (_predOrientation == Orientation.Idle)
        {
            return true;
        }
        else if ((_predOrientation == Orientation.Right || _predOrientation == Orientation.Left) &&
            (_orientation == Orientation.Down || _orientation == Orientation.Up))
        {
            return false;
        }
        else if ((_predOrientation == Orientation.Down || _predOrientation == Orientation.Up) &&
            (_orientation == Orientation.Left || _orientation == Orientation.Right))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void ActivatePolygonCollider2D()
    {
        _polygonCollider2D.enabled = true;
        _polygonCollider2D.isTrigger = true;
        _isPolygonCollider2DActivate = true;
    }

    private void DeactivatePolygonCollider2D()
    {
        _polygonCollider2D.enabled = false;
        _polygonCollider2D.isTrigger = false;
        _isPolygonCollider2DActivate = false;
    }

}
