using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy_object;
    [SerializeField]
    private float initial_spawn_delay;
    [SerializeField]
    private float current_spawn_delay;
    [SerializeField]
    float chance_of_spawn;


    private void Start()
    {
        current_spawn_delay = initial_spawn_delay;
        StartCoroutine(spawnEnemies());
    }

    private IEnumerator spawnEnemies()
    {
        //Wait 10 seconds at the start of the game

        yield return new WaitForSeconds(10f);
        while (true)
        {
            yield return new WaitForSeconds(current_spawn_delay);

            //Roll to see if this spawner will output an enemy
            var x = Random.Range(0,chance_of_spawn+1);

            Debug.Log(x);
            if(x > chance_of_spawn)
            {
                Instantiate(enemy_object, transform.position, transform.rotation);
            }

            if (!(current_spawn_delay < 2f))
            {
                //Slight decrease delay;
                current_spawn_delay -= 0.15f;

                if(current_spawn_delay < initial_spawn_delay/1.25)
                {
                    chance_of_spawn -= 0.1f;
                }
            }
        }
        
    }
}
