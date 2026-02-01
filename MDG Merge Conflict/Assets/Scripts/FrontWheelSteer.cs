using UnityEngine;

public class FrontWheelSteer : MonoBehaviour
{
    public float maxSteerAngle = 30f;

    void Update()
    {
        float steerInput = Input.GetAxis("Horizontal");
        float steerAngle = steerInput * maxSteerAngle;

        transform.localRotation = Quaternion.Euler(0f, steerAngle, 0f);
    }
}
