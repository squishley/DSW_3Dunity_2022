using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public bool isGameStarted;

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    public IEnumerator waitSpawner()
    {
        while (isGameStarted)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate (enemy, spawnPosition + transform.TransformPoint (0,0,0), gameObject.transform.rotation);

            yield return new WaitForSeconds (spawnWait);
        }
    }
}
