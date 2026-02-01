using UnityEngine;

public class WheelSuspension : MonoBehaviour
{
    public float suspensionAmount = 0.15f;
    public float suspensionSpeed = 5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float bounce =
            Mathf.Sin(Time.time * suspensionSpeed) * suspensionAmount;

        transform.localPosition =
            startPos + Vector3.up * bounce;
    }
}
