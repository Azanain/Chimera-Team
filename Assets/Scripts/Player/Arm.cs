using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private float rayDistance;
    private RaycastHit hit;
    private Ball ball;
    public static bool HaveBall { get; private set; }
    private void Awake()
    {
        EventManager.TakeBallEvent += TakeBall;
        EventManager.PutBallEvent += PutBall;
        EventManager.CheckPowerPushBallEvent += ThrowBall;
    }
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        { 
            if (hit.collider.CompareTag("Ball") && !HaveBall)
                EventManager.ActivationPanelBallActions(true);
            else
                EventManager.ActivationPanelBallActions(false);
        }
    }
    private void TakeBall()
    {
        if (hit.collider.CompareTag("Ball") && !HaveBall && hit.distance < rayDistance)
        {
            ball = hit.collider.GetComponent<Ball>();
            ball.PickUpBall();
            HaveBall = true;
        }
        else 
            Debug.Log("Обойдёшься!");
    }
    private void PutBall()
    {
        if (HaveBall)
        { 
            ball.ThrowBall(0);
            ball = null;
            HaveBall = false;
        }
        else
            Debug.Log("Обойдёшься!");
    }
    private void ThrowBall(float force)
    {
        ball.ThrowBall(force);
        ball = null;
        HaveBall = false;
    }
    private void OnDestroy()
    {
        EventManager.TakeBallEvent -= TakeBall;
        EventManager.PutBallEvent -= PutBall;
        EventManager.CheckPowerPushBallEvent -= ThrowBall;
    }
}
