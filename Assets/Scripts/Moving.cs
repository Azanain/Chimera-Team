using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Moving : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] float durationJump;
    [SerializeField] private AnimationCurve yPos;
   
    private Rigidbody rb;
    private bool canJump;
    private bool isJumping;
    private Vector3 moveInput;
    private PlayerAudio playerAudio;
    private bool isIdle;
    private float runIndex = 1f;
    
    private void Awake()
    {
        EventManager.JumpEvent += Jump;
        playerAudio = GetComponentInChildren<PlayerAudio>();
        rb = GetComponent<Rigidbody>();
    }
    private IEnumerator Jumping()
    {
        float seconds = 0;
        float progress = 0;
        while (progress < 1)
        {
            seconds += Time.deltaTime;
            progress = seconds / durationJump;
            rb.transform.position = new Vector3(transform.position.x, yPos.Evaluate(progress) * 2, transform.position.z);
            yield return null;
        }
        if (progress >= 1)
        {
            isJumping = false;
            StopCoroutine(Jumping());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
            canJump = true;
    }
    private void FixedUpdate()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveInput = transform.TransformDirection(moveInput);
        
        rb.velocity = moveInput * speed * runIndex;
    }
    private void Update()
    {
        if (!isIdle && InputController.IsShiftPressed && !isJumping)
        {
            runIndex = 2f;
            playerAudio.AudioRun();
        }
        else if (!isIdle && !InputController.IsShiftPressed && !isJumping)
        {
            runIndex = 1f;
            playerAudio.AudioWalk();
        }
        CheckMoving();
    }
    private void Jump()
    {
        if (canJump)
        {
            isJumping = true;
            playerAudio.AudioJump();
            StartCoroutine(Jumping());
            canJump = false;
        }
    }
    private void CheckMoving()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            isIdle = true;
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            isIdle = false;
    }
    private void OnDestroy()
    {
        EventManager.JumpEvent -= Jump;
    }
}
