using System.Collections;
using UnityEngine;

public class CheckGoal : MonoBehaviour
{
    private bool canGoal = true;
    /// <summary>
    /// тригер забития гола
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && canGoal)
        {
            EventManager.Goal();
            StartCoroutine(TimerGoal());
        }
    }
    private IEnumerator TimerGoal()
    {
        canGoal = false;
        yield return new WaitForSeconds(4);
        canGoal = true;
        StopCoroutine(TimerGoal());
    }
}
