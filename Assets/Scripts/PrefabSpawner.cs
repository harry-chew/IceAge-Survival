using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    private void SpawnPrefab(GameObject prefabToSpawn, Vector3 positionToSpawn)
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, positionToSpawn, Quaternion.identity);
        spawnedObject.name = prefabToSpawn.name;
    }
}
