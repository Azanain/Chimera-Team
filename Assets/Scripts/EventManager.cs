public class EventManager
{
    public delegate void EventManagerDel();
    public static event EventManagerDel JumpEvent;
    public static event EventManagerDel PutBallEvent;
    public static event EventManagerDel CheckBallEvent;
    public static event EventManagerDel NullObjectJointEvent;
    public static event EventManagerDel TakeBallEvent;
    public static event EventManagerDel GoalEvent;

    public delegate void EventManagerBoolDel(bool isTrue);
    public static event EventManagerBoolDel ActivationPanelBallActionsEvent;
    public static event EventManagerBoolDel Mouse2PressedEvent;

    public delegate void EventManagerFloatDel(float force);
    public static event EventManagerFloatDel CheckPowerPushBallEvent;

    public static void Jump()
    {
        JumpEvent?.Invoke();
    }
    public static void NullObjectJoint()
    {
        NullObjectJointEvent?.Invoke();
    }
    public static void ActivationPanelBallActions(bool isPicked)
    {
        ActivationPanelBallActionsEvent?.Invoke(isPicked);
    }
    public static void TakeBall()
    {
        TakeBallEvent?.Invoke();
    }
    public static void PutBall()
    {
        PutBallEvent?.Invoke();
    }
    public static void CheckBall()
    {
        CheckBallEvent?.Invoke();
    }
    public static void Mouse2Pressed(bool isPressed)
    {
        Mouse2PressedEvent?.Invoke(isPressed);
    }
    public static void CheckPowerPushBall(float force)
    {
        CheckPowerPushBallEvent?.Invoke(force);
    }
    public static void Goal()
    {
        GoalEvent?.Invoke();
    }
}
