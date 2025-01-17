using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 60;
    public int numberofTiles = 2;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberofTiles; i++)
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
        if (playerTransform.position.z - 50 > zSpawn - (numberofTiles * tileLength))
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileindex)
    {
        GameObject go = Instantiate(tilePrefabs[tileindex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }
    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

}
