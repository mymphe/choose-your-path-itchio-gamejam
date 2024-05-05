using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //[SerializeField] private GameObject explosionEffectPrefab; // Particle effect prefab for destruction

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rocket>() != null) // Check if the colliding object is the Rocket
        {
            // Instantiate explosion effect
            //Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

            // Notify HealthBar to take damage
            HealthBar healthBar = FindObjectOfType<HealthBar>();
            if (healthBar != null)
            {
                healthBar.TakeDamage();
            }

            Destroy(gameObject); 
        }
    }
}
