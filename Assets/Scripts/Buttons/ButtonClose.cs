using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClose : MonoBehaviour, IPointerClickHandler
{
    public static ButtonClose Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Player.Instance.IsFreezePlayer = false;
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
