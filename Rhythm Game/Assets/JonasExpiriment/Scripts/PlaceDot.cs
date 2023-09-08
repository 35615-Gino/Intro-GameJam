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
            Vector3 spawnPosition = transform.position;

            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn is not assigned!");
        }
    }
}
