using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] backgroundObjects;

    private const int MAX_OBJECTS = 5;

    private struct BackgroundObject
    {
        public GameObject obj;
        public float parallaxSpeed;
    }

    private List<BackgroundObject> spawnedObjects;

    private const float DESTROY_Y_POSITITON = -5f;

    private void Awake()
    {
        spawnedObjects = new List<BackgroundObject>();
    }

    private void Update()
    {
        if (spawnedObjects.Count < MAX_OBJECTS)
        {
            int objectsToSpawn = MAX_OBJECTS - spawnedObjects.Count;

            for (int i = 0; i < objectsToSpawn; i++)
            {
                GameObject backgroundObject = Instantiate(backgroundObjects[Random.Range(0, backgroundObjects.Length)]);
                float x = Random.Range(-8, 8);
                float y = Random.Range(5, 10);
                float z = Random.Range(5, 9);

                backgroundObject.transform.position = new Vector3(x, y, z);
                backgroundObject.transform.localScale = new Vector3(.1f, .1f, .1f);

                BackgroundObject bgObject;
                bgObject.obj = backgroundObject;
                bgObject.parallaxSpeed = 1 - (z / 10f);

                spawnedObjects.Add(bgObject);
            }
        }

        for (int i = 0; i < spawnedObjects.Count; i++) {
            BackgroundObject bgObject = spawnedObjects[i];

            bgObject.obj.transform.position += Rocket.Instance.GetSpeed() * bgObject.parallaxSpeed * Time.deltaTime * Vector3.down;

            if (bgObject.obj.transform.position.y < DESTROY_Y_POSITITON)
            {
                spawnedObjects.Remove(bgObject);
                Destroy(bgObject.obj);
            }
        }
    }
}
