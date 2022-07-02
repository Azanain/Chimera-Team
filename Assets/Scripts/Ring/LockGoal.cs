using UnityEngine;

public class LockGoal : MonoBehaviour
{
    [SerializeField] private GameObject lockRingBot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            lockRingBot.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            lockRingBot.SetActive(true);
        }
    }
}
