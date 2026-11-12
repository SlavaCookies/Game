using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTake : MonoBehaviour, IPointerClickHandler
{
    private InventoryObject _selectedInventoryObject;
    [SerializeField] private GameObject putFigure;
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 scale;
    [SerializeField] private Vector3 positionIsScaleActive;
    [SerializeField] private Vector3 scaleIsScaleActive;
    private void Update()
    {
        if (BackpackOpen.Instance.IsScaleActiveBackpack)
        {
            gameObject.transform.localPosition = positionIsScaleActive;
            gameObject.transform.localScale = scaleIsScaleActive;
        } else
        {
            gameObject.transform.localPosition = position;
            gameObject.transform.localScale = scale;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (BackpackOpen.Instance.SelectedObject != null)
            {
                _selectedInventoryObject = BackpackOpen.Instance.SelectedObject;
                PlayerObject.Instance.SpriteRenderer.sprite = _selectedInventoryObject.SpriteObject;
                PlayerObject.Instance.NameObject = _selectedInventoryObject.NameObject;
                PlayerObject.Instance.gameObject.transform.localScale = _selectedInventoryObject.ScaleItem;//new Vector3(0.5f, 0.5f, 1f);
                PlayerObject.Instance.GamePlayerObject = _selectedInventoryObject.gameObject;
                if (_selectedInventoryObject.NameObject == FiguresSO.namePawn)
                {
                    GameObject newPutFigure = Instantiate(putFigure);
                }
                BackpackOpen.Instance.CloseBackpack();
            }
        }
    }
}
