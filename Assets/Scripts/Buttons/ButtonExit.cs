using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonExit : MonoBehaviour, IPointerClickHandler
{
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
            BackpackOpen.Instance.CloseBackpack();

        }
    }
}
