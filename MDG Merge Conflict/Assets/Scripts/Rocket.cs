using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    public ParticleSystem smokeTrail;
    // public ParticleSystem smokeTrail;
    public float lifeTime = 5f;

    void Start()
    {
        // Start particles
        // if (launchEffect) launchEffect.Play();
        if (smokeTrail) smokeTrail.Play();
Debug.Log(smokeTrail.isPlaying);

        Destroy(gameObject, lifeTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        // If missile hits player → restart game
        if (collision.gameObject.CompareTag("BikeEnemy"))
        {
            Debug.Log("You Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
         if (collision.gameObject.CompareTag("Missile"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }

        // Stop smoke & destroy missile
        // if (smokeTrail) smokeTrail.Stop();
        // Destroy(gameObject, 0.1f);
    }
}
