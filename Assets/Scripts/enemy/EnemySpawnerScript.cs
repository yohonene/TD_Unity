using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy_object;
    [SerializeField]
    private GameObject second_enemy_object;
    [SerializeField]
    private float initial_spawn_delay;
    [SerializeField]
    private float current_spawn_delay;
    [SerializeField]
    float chance_of_spawn;
    [SerializeField]
    float chance_for_2nd_enemy;


    private void Start()
    {
        current_spawn_delay = initial_spawn_delay;
        StartCoroutine(spawnEnemies());
    }

    private IEnumerator spawnEnemies()
    {
        //Wait 10 seconds at the start of the game
        GameObject enemy_to_be_spawned;

        yield return new WaitForSeconds(10f);
        while (true)
        {
            yield return new WaitForSeconds(current_spawn_delay);

            //Roll to see if this spawner will output an enemy
            var x = Random.Range(0,chance_of_spawn+1);
            if(x > chance_of_spawn)
            {
                enemy_to_be_spawned = enemy_object;

                if (chance_of_spawn < initial_spawn_delay / 1.25)
                {
                    var y = Random.Range(1, chance_for_2nd_enemy + 1);
                    Debug.Log("rollan");
                    //Spawn lil gobby if chance has been met
                    if (y >= chance_for_2nd_enemy ) { enemy_to_be_spawned = second_enemy_object; }
                }

                Instantiate(enemy_to_be_spawned, transform.position, transform.rotation);
            }

            if (!(current_spawn_delay < 2f))
            {
                //Slight decrease delay;
                current_spawn_delay -= 0.3f;

                
                if(current_spawn_delay < initial_spawn_delay/1.5)
                {
                    if (chance_of_spawn != 1) { chance_of_spawn -= 0.2f; }
                    
                }
            }
            else
            {
                if (Random.Range(1, 2) == 1)
                {
                    enemy_to_be_spawned = enemy_object;
                    Instantiate(enemy_to_be_spawned, transform.position, transform.rotation);
                    //SPAWN EVEN MORE MUAHHAAHHA
                }
            }
        }
        
    }
}
