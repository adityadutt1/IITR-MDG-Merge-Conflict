using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketEnemy : MonoBehaviour
{
    public ParticleSystem smokeTrail;
    // public ParticleSystem smokeTrail;
    public float lifeTime = 5f;
//  public GameOverUI gameOverUI;
    void Start()
    {
        // gameOverUI = FindFirstObjectByType<GameOverUI>();
        // Start particles
        // if (launchEffect) launchEffect.Play();
        if (smokeTrail){
            smokeTrail.Play();}
        Destroy(gameObject, lifeTime);
    }
    // void OnCollisionEnter(Collision collision)
    // {
    //     // If missile hits player → restart game
    //     if (collision.transform.root.CompareTag("Player"))
    //     {
    //         Debug.Log("Game Over");
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //     }

    //     // Stop smoke & destroy missile
    //     if (smokeTrail) smokeTrail.Stop();
    //     Destroy(gameObject, 0.1f);
    // }
    void OnCollisionEnter(Collision collision)
{
    Debug.Log("Rocket hit: " + collision.gameObject.name);

    if (collision.transform.root.CompareTag("Player"))
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // gameOverUI.ShowGameOver();
    }

    if (smokeTrail) smokeTrail.Stop();
    Destroy(gameObject, 0.1f);
}

}
