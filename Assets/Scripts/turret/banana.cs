using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour
{

    [SerializeField]
    turret turret_values;
    [SerializeField]
    GameObject particle_system;

    private float damage;

    private void Start()
    {
        damage = turret_values.getDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Play particle explosion and deal 5 damage, kill banana after
            other.gameObject.TryGetComponent(out enemy enemy_class);
            var explosion = Instantiate(particle_system, other.gameObject.transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            enemy_class.damageEnemy(damage);
            Destroy(gameObject);
        }
    }
}
