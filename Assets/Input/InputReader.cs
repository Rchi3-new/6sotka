using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public System.Action<Vector2> OnClick;
    [SerializeField] private GameObject clickIndicatorPrefab;
    
    private BuildSystem buildSystem;

    void Update()
    {
        // Mouse click
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 screen = Mouse.current.position.ReadValue();
            SendClick(screen);
        }

        // Touch
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 screen = Touchscreen.current.primaryTouch.position.ReadValue();
            SendClick(screen);
        }
    }

    private void SendClick(Vector2 screenPosition)
    {
        Vector3 screenPoint = new Vector3(
            screenPosition.x,
            screenPosition.y,
            Mathf.Abs(Camera.main.transform.position.z)
        );

        Vector3 world = Camera.main.ScreenToWorldPoint(screenPoint);
       
        OnClick?.Invoke(new Vector2(world.x, world.y));
    }
}