using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform player;
    public GameObject rocketPrefab;
    public Transform launchPoint;

    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    public float shootInterval = 2f;
    public float rocketForce = 700f;
    public float attackRange = 30f;

    private float shootTimer;
    public AudioSource launcherSound;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        if (!player) return;

        float distance =
            Vector3.Distance(transform.position, player.position);

        // Rotate toward player
        Vector3 direction =
            (player.position - transform.position).normalized;

        Quaternion lookRotation =
            Quaternion.LookRotation(direction);

        rb.rotation = Quaternion.Slerp(
            rb.rotation,
            lookRotation,
            rotateSpeed * Time.fixedDeltaTime
        );

        // Move toward player
        if (distance > attackRange * 0.7f)
        {
            rb.MovePosition(
                rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime
            );
        }

        // Shoot rockets
        shootTimer += Time.fixedDeltaTime;

        if (distance <= attackRange && shootTimer >= shootInterval)
        {
            ShootRocket();
            shootTimer = 0f;
        }
    }

    // void ShootRocket()
    // {
    //     launcherSound.Play();
    //     GameObject rocket = Instantiate(
    //         rocketPrefab,
    //         launchPoint.position,
    //         launchPoint.rotation
    //     );

    //     Rigidbody rocketRb = rocket.GetComponent<Rigidbody>();
    //     rocketRb.AddForce(
    //         launchPoint.forward * rocketForce,
    //         ForceMode.Impulse
    //     );
    // }
//     void ShootRocket()
// {
//     launcherSound.Play();

//     GameObject rocket = Instantiate(
//         rocketPrefab,
//         launchPoint.position,
//         launchPoint.rotation
//     );

//     // IGNORE collision with enemy itself
//     Collider rocketCol = rocket.GetComponent<Collider>();
//     Collider enemyCol = GetComponent<Collider>();

//     if (rocketCol && enemyCol)
//         Physics.IgnoreCollision(rocketCol, enemyCol);

//     Rigidbody rocketRb = rocket.GetComponent<Rigidbody>();
//     rocketRb.AddForce(
//         launchPoint.forward * rocketForce,
//         ForceMode.Impulse
//     );
// }
void ShootRocket()
{
        launchPoint.Rotate(0f, Random.Range(-5f, 5f), 0f);
    launcherSound.Play();

    GameObject rocket = Instantiate(
        rocketPrefab,
        launchPoint.position,
        launchPoint.rotation
    );

    // Ignore collision with ALL enemy colliders
    Collider[] enemyColliders = GetComponentsInChildren<Collider>();
    Collider rocketCollider = rocket.GetComponent<Collider>();

    foreach (Collider col in enemyColliders)
    {
        Physics.IgnoreCollision(rocketCollider, col);
    }

    Rigidbody rocketRb = rocket.GetComponent<Rigidbody>();
    rocketRb.AddForce(
        launchPoint.forward * rocketForce,
        ForceMode.Impulse
    );
}


}
