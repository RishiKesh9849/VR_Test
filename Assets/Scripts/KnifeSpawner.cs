using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    public GameObject knifePrefab;
    public Transform spawnPoint;
    public float spawnCheckInterval = 1f;
    private bool canSpawn = true;

    void Update()
    {
        if (canSpawn && transform.childCount == 0)
        {
            StartCoroutine(SpawnKnifeWithDelay());
        }
    }

    IEnumerator SpawnKnifeWithDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnCheckInterval);


        if (transform.childCount == 0)
        {
            Instantiate(knifePrefab, spawnPoint.position, spawnPoint.rotation, transform);
        }

        canSpawn = true;
    }
}
