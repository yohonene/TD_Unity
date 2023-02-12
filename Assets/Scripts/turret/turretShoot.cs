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
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    private float ray_distance;

    void Awake()
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
        //While raycast hits enemy in line
        while (true)
        {
            //Check if there is an enemy infront
            if (raycastEnemyCheck())
            {
                //Shoot projectile and move
                StartCoroutine(Shoot());
                //Spawn X amount of projectiles within 1 second
                yield return new WaitForSeconds(1 / rate_of_fire);
            }
            //Else return loop
            yield return null;
        }

        
    }

    private void FixedUpdate()
    {
        //Show what turrets are aiming at
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*ray_distance, Color.blue);
    }

    private bool raycastEnemyCheck()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,ray_distance,mask))
        {
            return true;
        }
        return false;
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
