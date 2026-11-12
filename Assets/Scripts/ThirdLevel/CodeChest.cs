using UnityEngine;

public class CodeChest : MonoBehaviour
{
    public static CodeChest Instance { get; private set; }
    [SerializeField] private SpriteObjectCodeChest firstObject;
    [SerializeField] private SpriteObjectCodeChest secondObject;
    [SerializeField] private SpriteObjectCodeChest thirdObject;
    [SerializeField] private SpriteObjectCodeChest fourthObject;

    private SpriteRenderer _spriteRendererFirst;
    private SpriteRenderer _spriteRendererSecond;
    private SpriteRenderer _spriteRendererThird;
    private SpriteRenderer _spriteRendererFourth;
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    { 
        _spriteRendererFirst = firstObject.GetComponent<SpriteRenderer>();
        _spriteRendererSecond = secondObject.GetComponent<SpriteRenderer>();
        _spriteRendererThird = thirdObject.GetComponent<SpriteRenderer>();
        _spriteRendererFourth = fourthObject.GetComponent<SpriteRenderer>();
        ChangeSpriteInTheObjects();
    }

    public void ChangeSpriteInTheObjects()
    {
        Debug.Log($"First Object: {firstObject.NumberSpriteObject}, " +
            $"Second Object: {secondObject.NumberSpriteObject}, " +
            $"Third Object: {thirdObject.NumberSpriteObject}, " +
            $"Fourth Object: {fourthObject.NumberSpriteObject}");
                
        _spriteRendererFirst.sprite = SpritesGallery.Instance.SpritesGallerys[firstObject.NumberSpriteObject];
        _spriteRendererSecond.sprite = SpritesGallery.Instance.SpritesGallerys[secondObject.NumberSpriteObject];
        _spriteRendererThird.sprite = SpritesGallery.Instance.SpritesGallerys[thirdObject.NumberSpriteObject];
        _spriteRendererFourth.sprite = SpritesGallery.Instance.SpritesGallerys[fourthObject.NumberSpriteObject];
        LockChestIsUnlock();
    }

    private void LockChestIsUnlock()
    {
        if (firstObject.NumberSpriteObject == 9 &&
            secondObject.NumberSpriteObject == 0 &&
            thirdObject.NumberSpriteObject == 5 &&
            fourthObject.NumberSpriteObject == 8)
        {
            Chest.Instance.ChangeSprite();
            SpawnObjectsBeforeOpenChest.Instance.SpawnObjects(Chest.Instance.ParentTransform);
            GameInput.Instance.FButtons.Remove(CodeChestClosedButton.Instance);
            Player.Instance.IsFreezePlayer = false;
            Destroy(gameObject);
        }
    }
}
