using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnerRate = 1;
    private float timeLeftBeforeSpawn = 0;
    private SpawnPoint[] spawnPoints;
    public GameObject[] ennemiPrefab;


	// Use this for initialization
	void Start () {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        timeLeftBeforeSpawn = 1 / spawnerRate;
    }

    // Update is called once per frame
    void Update () {
        UpdateSpawn();

    }

    private void UpdateSpawn()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;
        if (timeLeftBeforeSpawn <0)
        {
            SpawnCube();
            timeLeftBeforeSpawn = 1 / spawnerRate;
            
        }
    }

    private void SpawnCube()
    {
        int countSpawnPoint = spawnPoints.Length;
        int randomSpawnPointIndex = Random.Range(0, countSpawnPoint);
        SpawnPoint spawnPointRandomlySelected = spawnPoints[randomSpawnPointIndex];
        GameObject newCube = Instantiate(ennemiPrefab[Random.Range(0, 2)], spawnPointRandomlySelected.GetPosition(), spawnPointRandomlySelected.transform.rotation);

    }

}
