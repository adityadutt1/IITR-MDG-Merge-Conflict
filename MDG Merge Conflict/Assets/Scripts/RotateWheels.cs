using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    public float wheelRotateSpeed = 360f;
    private float moveInput;

    void Update()
    {
        moveInput = Input.GetAxis("Vertical"); // W/S or Up/Down

        float wheelRotate =
            moveInput * wheelRotateSpeed * Time.deltaTime;

        // Rotate wheel visually (X-axis)
        transform.Rotate(Vector3.right, wheelRotate);
    }
}
