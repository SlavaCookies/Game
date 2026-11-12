using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonUpDownCodeChest : MonoBehaviour, IPointerClickHandler
{
    private enum ButtonAction
    {
        Up,
        Down,
        None
    };
    [SerializeField] private ButtonAction buttonAction;
    [SerializeField] private SpriteObjectCodeChest spriteObject;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (buttonAction == ButtonAction.Up)
            {
                if (spriteObject.NumberSpriteObject == 9)
                {
                    spriteObject.NumberSpriteObject = 0;
                }
                else
                {
                    spriteObject.NumberSpriteObject++;
                }
            }
            else
            {
                if (spriteObject.NumberSpriteObject == 0)
                {
                    spriteObject.NumberSpriteObject = 9;
                }
                else
                {
                    spriteObject.NumberSpriteObject--;
                }
            }
            CodeChest.Instance.ChangeSpriteInTheObjects();
            Debug.Log("click");
        }
    }
}
