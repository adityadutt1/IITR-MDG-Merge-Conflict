using UnityEngine;

public class BikeLean : MonoBehaviour
{
    public float maxLeanAngle = 25f;
    public float leanSpeed = 6f;

    private float currentLean;

    void Update()
    {
        float turn = Input.GetAxis("Horizontal");
        float speed = Mathf.Abs(Input.GetAxis("Vertical"));

        float targetLean = -turn * maxLeanAngle * speed;

        currentLean = Mathf.Lerp(
            currentLean,
            targetLean,
            leanSpeed * Time.deltaTime
        );

        transform.localRotation =
            Quaternion.Euler(0f, 0f, currentLean);
    }
}
