using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageTiles : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = (float)15.43;
    public int numberOfTiles = 5;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject> ();
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 20 >  zSpawn - (numberOfTiles * tileLength)) 
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
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
