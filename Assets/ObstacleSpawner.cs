using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public BoxCollider spawnArea;
    public float spawnRate = 1f;
    public float asteroidSpeed = 5f;

    private float nextTimeToSpawn = 0f;

    private void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            SpawnAsteroid();
            nextTimeToSpawn = Time.time + 1f / spawnRate;
        }
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        );

        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        Rigidbody rb = asteroid.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = asteroid.AddComponent<Rigidbody>();
        }

        rb.useGravity = false; // Turn off gravity
        rb.drag = 0;           // Ensure no drag affects the movement
        rb.velocity = new Vector3(0, -asteroidSpeed, 0); // Consistently apply velocity
    }

}
