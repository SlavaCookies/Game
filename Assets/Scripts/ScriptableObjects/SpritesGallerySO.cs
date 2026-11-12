using UnityEngine;

[CreateAssetMenu(fileName = "SpritesGallerySO", menuName = "Scriptable Objects/SpritesGallerySO")]
public class SpritesGallerySO : ScriptableObject
{
    [SerializeField] public Sprite[] spritesGallery = new Sprite[10];    


}
