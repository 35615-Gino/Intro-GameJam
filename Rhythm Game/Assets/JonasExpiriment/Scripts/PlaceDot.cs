using UnityEngine;

public class PlaceDot : MonoBehaviour
{
    public GameObject prefabToSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnPrefab();
        }
    }

    void SpawnPrefab()
    {
        if (prefabToSpawn != null)
        {
            // Get the position of the current GameObject
            Vector3 spawnPosition = transform.position;

            // Instantiate the prefab at the current position
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn is not assigned!");
        }
    }
}
