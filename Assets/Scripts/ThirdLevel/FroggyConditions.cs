using UnityEngine;

public class FroggyConditions : MonoBehaviour, IConditionsDialog
{
    public static FroggyConditions Instance { get; private set; }
    [SerializeField] private MonoBehaviour itext;
    [SerializeField] private Vector3 picturePosition;
    [SerializeField] private Transform mapTransform;
    [SerializeField] private ButtonVision buttonVision;
    private IText _itext;
    private bool _isFirstDialogTalk = false;
    public bool IsFirstDialogTalk
    {
        get { return _isFirstDialogTalk; }
        set { _isFirstDialogTalk = value; }
    }
    private void Awake()
    {
        Instance = this;
        _itext = itext as IText;
        buttonVision.DistanceToView = 0f;
    }
    public void Condition()
    {
        if (PlayerObject.Instance.NameObject == PictureSO.nameObject)
        {
            GameObject newObject = Instantiate(PlayerObject.Instance.GamePlayerObject, mapTransform);
            newObject.transform.localPosition = picturePosition;
            newObject.AddComponent<SpriteRenderer>();
            newObject.GetComponent<SpriteRenderer>().sprite = PlayerObject.Instance.SpriteRenderer.sprite;
            newObject.GetComponent<SpriteRenderer>().sortingOrder = -2;
            PlayerObject.Instance.SpriteRenderer.sprite = null;
            PlayerObject.Instance.NameObject = " ";
            InventoryObject inventoryObject = BackpackOpen.Instance.GetItemFromInventory(PictureSO.nameObject);
            Debug.Log("Delete Objects");
            if (inventoryObject != null)
            {
                for (int i = 0; i < BackpackOpen.Instance.InventoryObjects.Count; ++i)
                {
                    if (inventoryObject.NameObject == BackpackOpen.Instance.InventoryObjects[i].NameObject)
                    {
                        BackpackOpen.Instance.InventoryScalableObjects.RemoveAt(i);
                        i = BackpackOpen.Instance.InventoryObjects.Count;
                        Debug.Log("Here");
                    }
                }
                BackpackOpen.Instance.InventoryObjects.Remove(inventoryObject);
            }
            DialogFunction.Instance.Dialog(1);
            PartPictureInterractFroggy.Instance.ChangeButtonVision();
        }
    }

    public void ChangeButtonVisionView()
    {
        buttonVision.DistanceToView = 1f;
    }
}
