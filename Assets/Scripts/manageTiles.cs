using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageTiles : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject coinPrefab;
    public float zSpawn = 0;
    public float tileLength = 15.43f;
    public int numberOfTiles = 5;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    void Update()
    {
        if (playerTransform.position.z - 20 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;

        // Spawn coins for the newly spawned tile
        SpawnCoins(go, Random.Range(0, 5));
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public void SpawnCoins(GameObject tile, int spawnedCoinsNumber)
    {
        Collider tileCollider = tile.GetComponent<Collider>();
        if (tileCollider != null)
        {
            for (int i = 0; i < spawnedCoinsNumber; i++)
            {
                Vector3 randomPosition = GetRandomPointInCollider(tileCollider);
                Instantiate(coinPrefab, randomPosition, Quaternion.identity);
            }
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Bounds bounds = collider.bounds;

        // Calculate lane width
        float laneWidth = bounds.size.x / 3;

        // Choose a random lane (0, 1, or 2)
        int lane = Random.Range(0, 3);

        // Calculate the x position in the middle of the chosen lane
        float xPosition = bounds.min.x + laneWidth * (lane + 0.5f);

        // Generate a random z position within the bounds
        float zPosition = Random.Range(bounds.min.z, bounds.max.z);

        // Set the y position to be slightly above the ground
        float yPosition = bounds.min.y + 1;

        Vector3 point = new Vector3(xPosition, yPosition, zPosition);
        return point;
    }
}
