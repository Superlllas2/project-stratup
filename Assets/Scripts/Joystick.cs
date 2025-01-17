using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public RectTransform joystickBackground;
    public RectTransform joystickHandle;

    private Vector2 inputVector;

    public Vector2 InputDirection => inputVector; // Public property to get input direction

    public void OnDrag(PointerEventData eventData)
    {
        var position = RectTransformUtility.WorldToScreenPoint(null, joystickBackground.position); 
        inputVector = (eventData.position - position) / (joystickBackground.sizeDelta / 2);
        inputVector = inputVector.magnitude > 1.0f ? inputVector.normalized : inputVector;
        joystickHandle.anchoredPosition = inputVector * (joystickBackground.sizeDelta / 2);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Reset joystick when the drag ends
        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }
}