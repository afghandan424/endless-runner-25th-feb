using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = 5.0f; //where to spawn tile in Z
    private float tileLength = 10.0f;
    private float safetyNet = 10.0f;
    private int TilesOnScreen = 7;
    private List<GameObject> activeTiles;
    private int lastPrefabIndex = 0;


	void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

        for (int i = 0; i < TilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();       
        }

	}
	
	// Update is called once per frame
	void Update () {
        if(playerTransform.position.z - safetyNet > (spawnZ - TilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
		
	}

    void SpawnTile(int prefabIndex = -1)
    {
        GameObject GO;
        if (prefabIndex == -1)
            GO = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            GO = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        GO.transform.SetParent(transform);
        GO.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(GO);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
           
    }

}
