using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class turretShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float projectile_speed;
    [SerializeField]
    private float total_range;
    [SerializeField]
    private float rate_of_fire;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootTimer());
    }

    /// <summary>
    /// Shoots X amount of projectiles per second
    /// Calls Shoot() Coroutine
    /// While(true) infinite loop
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShootTimer()
    {
        while (true)
        {
            //Shoot projectile and move
            StartCoroutine(Shoot());
            //Spawn X amount of projectiles within 1 second
            yield return new WaitForSeconds(1/rate_of_fire);
        }

        
    }

    /// <summary>
    /// Spawns a bullet and shoots forward, every fixed frame amount of seconds
    /// Duration of bullet depends on user 
    /// <param>total_range</param>
    /// </summary>
    /// <returns></returns>
    private IEnumerator Shoot() 
    {
        //Spawn bullet, set to shooters position and rotation
        var new_bullet = Instantiate(bullet, transform.position, transform.rotation);
        //Shoot to max total range
        for (int x = 0; x < total_range; x++)
        {
            new_bullet.transform.Translate(Vector3.forward * projectile_speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        //Destroy after it has reached maximum range
        Destroy(new_bullet);
        
    }

}
