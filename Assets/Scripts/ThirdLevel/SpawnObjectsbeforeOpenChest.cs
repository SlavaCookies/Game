using UnityEngine;

public class SpawnObjectsBeforeOpenChest : MonoBehaviour
{
    public static SpawnObjectsBeforeOpenChest Instance { get; private set; }
    [SerializeField] private GameObject partPicture;
    [SerializeField] private GameObject picture;
    [SerializeField] private GameObject coin;
    private void Awake()
    {
        Instance = this;
    }
    public void SpawnObjects(Transform transformParent)
    {
        GameObject newObjectsPartPicture = Instantiate(partPicture, transformParent);
        newObjectsPartPicture.name = PartPictureSO.nameObject2;
        GameObject newObjectPicture = Instantiate(picture, transformParent);
        newObjectPicture.name = PictureSO.nameObject;
        GameObject newObjectCoin = Instantiate(coin, transformParent);
        newObjectCoin.name = CoinGallerySO.nameObject;
    }
}
