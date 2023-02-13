using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    turret tower_owner;

    private float damage = 1;

    private void Awake()
    {
        damage = tower_owner.getDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if enemy is hit
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Attempt to get enemy class access
            other.gameObject.TryGetComponent(out enemy enemy_class);
            //Damage enemy;
            enemy_class.damageEnemy(damage);
            //Hide bullet so it seems like it was absorbed.
            gameObject.SetActive(false);
        }
    }
}
