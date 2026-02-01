using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float rotateSpeed = 5f;
    // public float killDistance = 1.5f;

    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Keep enemy upright
        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        if (!player) return;

        // Direction to player
        Vector3 direction =
            (player.position - transform.position).normalized;

        // Rotate toward player
        Quaternion lookRotation =
            Quaternion.LookRotation(direction);

        rb.rotation = Quaternion.Slerp(
            rb.rotation,
            lookRotation,
            rotateSpeed * Time.fixedDeltaTime
        );

        // Move forward
        rb.MovePosition(
            rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime
        );

        // Kill if close
        float distance =
            Vector3.Distance(transform.position, player.position);

        // if (distance < killDistance)
        // {
        //     SceneManager.LoadScene(
        //         SceneManager.GetActiveScene().buildIndex
        //     );
        // }
    }
}
