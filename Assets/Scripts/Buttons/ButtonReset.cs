using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonReset : MonoBehaviour, IPointerClickHandler
{
    public static ButtonReset Instance { get; private set; }
    [SerializeField] private Vector3 boxPosition;
    [SerializeField] private GameObject box;
    private void Awake()
    {
        Instance = this;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            box.gameObject.transform.localPosition = boxPosition;
        }
    }
}
