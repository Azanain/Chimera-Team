using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && Arm.HaveBall)
            EventManager.PutBall();
    }
}
