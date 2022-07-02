using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField] private float sensivity = 5f;
    [SerializeField] private float smoothTime = 0.1f;
    [SerializeField] Transform cam;
    private float xRot, yRot;
    private float xRotCurrent, yRotCurrent;
    private float currentVelosityX, currentVelosityY;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
         MouseMove();
    }
    private void MouseMove()
    {
        xRot += Input.GetAxis("Mouse X") * sensivity;
        yRot += Input.GetAxis("Mouse Y") * sensivity;
        yRot = Mathf.Clamp(yRot, -50, 60);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelosityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelosityY, smoothTime);

        transform.rotation = Quaternion.Euler(0f, xRotCurrent, 0f);
        cam.rotation = Quaternion.Euler(-yRotCurrent, xRotCurrent, 0f);
    }
}
