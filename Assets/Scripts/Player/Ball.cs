using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform arm;
    private Rigidbody rb;

    private AudioSource ballAudioSource;
    
    [SerializeField] private AudioClip ballHit;
    [SerializeField] private AudioClip ballTake;
    [SerializeField] private AudioClip ballPut;
    [SerializeField] private AudioClip ballThrow;
    private void Awake()
    {
        ballAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        EventManager.PutBallEvent += AudioPutBall;
    }
    public void PickUpBall()
    {
        if (arm.childCount < 2)
        {
            transform.SetParent(arm);
            transform.position = arm.position;
            transform.rotation = arm.rotation;
            ballAudioSource.PlayOneShot(ballTake);
            rb.isKinematic = true;
        }
        else
            Debug.Log("Обойдёшься!");
    }
    public void ThrowBall(float force)
    {
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(transform.forward * force);
        ballAudioSource.PlayOneShot(ballThrow);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ballAudioSource.PlayOneShot(ballHit);
    }
    private void AudioPutBall()
    {
        if (Arm.HaveBall)
            ballAudioSource.PlayOneShot(ballPut);
    }
    private void OnDestroy()
    {
        EventManager.PutBallEvent -= AudioPutBall;
    }
}
