using UnityEngine;

public class SpriteObjectCodeChest : MonoBehaviour
{
    [SerializeField] private int numberSpriteObject;
    private SpriteRenderer _spriteRenderer;    
    public int NumberSpriteObject
    {
        get { return numberSpriteObject; }
        set { numberSpriteObject = value; }
    }
    public SpriteRenderer spriteRenderer
    {
        get { return _spriteRenderer; }
        set { _spriteRenderer = value; }
    }
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();    
    }
}
