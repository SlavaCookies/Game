using UnityEngine;
using UnityEngine.Rendering;

public class PlayerObject : MonoBehaviour
{
    public static PlayerObject Instance { get; private set; }
    private SpriteRenderer _spriteRenderer;
    private string _nameObject;
    private GameObject _gameObject;
    public SpriteRenderer SpriteRenderer {
        get { return _spriteRenderer; }
        set { _spriteRenderer = value; }
    }
    public string NameObject
    {
        get { return _nameObject; }
        set { _nameObject = value; }
    }
    public GameObject GamePlayerObject
    {
        get { return _gameObject; }
        set { _gameObject = value; }
    }
    private void Awake()
    {
        Instance = this;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ClearPlayerObjectItemInventory()
    {
        _spriteRenderer.sprite = null;
        _nameObject = " ";
        _gameObject = null;
    }
}
