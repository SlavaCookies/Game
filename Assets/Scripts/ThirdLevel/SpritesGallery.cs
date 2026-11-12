using UnityEngine;

public class SpritesGallery : MonoBehaviour
{
    public static SpritesGallery Instance { get; private set; }
    [SerializeField] private Sprite[] spritesGallery = new Sprite[10];
    public Sprite[] SpritesGallerys
    {
        get { return spritesGallery; }
        set { spritesGallery = value; }
    }
    private void Awake()
    {
        Instance = this;
    }
}
