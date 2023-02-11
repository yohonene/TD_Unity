using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy_object;
    [SerializeField]
    private float spawn_delay;

    private void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    private IEnumerator spawnEnemies()
    {
        while (true)
        {
            Instantiate(enemy_object, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawn_delay);
        }
        
    }
}
