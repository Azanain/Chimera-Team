using UnityEngine;

public class InputController : MonoBehaviour
{
    public static bool IsShiftPressed { get; private set; }
    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("space")))
        {
            EventManager.Jump();
        }
        if (Event.current.Equals(Event.KeyboardEvent("E")))
        {
            EventManager.TakeBall();
        }
        if (Event.current.Equals(Event.KeyboardEvent("F")))
        {
            EventManager.PutBall();
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
            EventManager.Mouse2Pressed(true);
        else if (Input.GetMouseButtonUp(1))
            EventManager.Mouse2Pressed(false);

        if (Input.GetKey(KeyCode.LeftShift))
            IsShiftPressed = true;
        else
            IsShiftPressed = false;
    }
}
