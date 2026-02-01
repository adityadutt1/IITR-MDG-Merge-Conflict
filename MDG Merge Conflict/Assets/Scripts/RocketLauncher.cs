using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform launchPoint;
    public AudioSource launcherSound;
    public float launchForce = 800f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            launcherSound.Play();
            LaunchRocket();
        }
    }

    void LaunchRocket()
    {
        GameObject rocket =
            Instantiate(rocketPrefab, launchPoint.position, launchPoint.rotation);

        Rigidbody rb = rocket.GetComponent<Rigidbody>();
        rb.linearVelocity = GetComponent<Rigidbody>().linearVelocity;
        rb.AddForce(launchPoint.forward * launchForce, ForceMode.Impulse);
    }
}
