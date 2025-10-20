using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform knob;
    [SerializeField] private float handleLimit = 100f; // max distance knob can move (pixels)

    private Vector2 inputVector;

    // Read-only properties for your InputManager
    public float Horizontal => inputVector.x;
    public float Vertical => inputVector.y;
    public Vector2 Direction => new Vector2(Horizontal, Vertical);

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convert screen point to local point in joystick rect
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPos
        );

        // Clamp the knob within the handleLimit
        localPos = Vector2.ClampMagnitude(localPos, handleLimit);

        // Normalize input vector (-1 to 1)
        inputVector = localPos / handleLimit;

        // Move knob
        knob.anchoredPosition = inputVector * handleLimit;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        knob.anchoredPosition = Vector2.zero;
    }
}