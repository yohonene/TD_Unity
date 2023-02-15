using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private float move_speed;
    [SerializeField] 
    private float attack_speed;
    [SerializeField]
    private Renderer enemy_renderer;
    [SerializeField]
    enemyHealthText textScript;
    [SerializeField]
    private bool _towerNotNear;
    [SerializeField]
    private bool isAttacking;
    [SerializeField]
    float ray_distance;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    Animator enemy_animator;

    private Color org_colour;


    private void Start()
    {
        org_colour = enemy_renderer.material.color;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * ray_distance, Color.red);
        //Raycast if tower is close
        towerDistanceCheck();
        //If the raycast does not detect a tower slightly infront of them, move forward
        if (_towerNotNear)
        {
            transform.Translate(Vector3.forward * move_speed * Time.deltaTime);
        }
        
    }

    private void towerDistanceCheck()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, ray_distance, mask))
        {
            //Send tower infront of enemy to attack method - do not call if already attacking
            if (!isAttacking) { StartCoroutine(attackTower(hit.transform.gameObject)); }
            _towerNotNear = false;
            return;
        }
        else
        {
            _towerNotNear = true;
            enemy_animator.SetBool("isAttacking", false);
        }

        
    }

    /// <summary>
    /// Attacks enemy tower, calls damageTower() method
    /// </summary>
    /// <param name="tower"></param>
    /// <returns></returns>
    private IEnumerator attackTower(GameObject tower)
    {
        isAttacking = true;
        tower.TryGetComponent(out turret _turret);
        if (_turret)
        {
            enemy_animator.SetBool("isAttacking", true);
            _turret.damageTower();
            
        }
        yield return new WaitForSeconds(1f / attack_speed);
        //After attack delay, allow for more attacks
        isAttacking = false;


    }

    /// <summary>
    /// Subtracts health from enemy and calls change colour
    /// Default damage of 1, if damage is not provided
    /// </summary>
    public void damageEnemy(float dmg = 1)
    {
        //Change health
        _health -= dmg;
        //Visually change appearance to show that damage was taken
        StartCoroutine(change_colour());

        //Kill enemy if health reaches 0
        if (_health <= 0)
        {
            Destroy(gameObject);
        }

        //Update Text Above Enemy
        textScript.textUpdate();
    }

    /// <summary>
    /// Returns health to requestee
    /// </summary>
    /// <returns></returns>
    public float getHealth()
    {
        return _health;
    }

    private IEnumerator change_colour()
    {
        //Change colour to red
        enemy_renderer.material.color = Color.red;
        //Wait 1 second before changing back
        yield return new WaitForSeconds (0.1f);
        enemy_renderer.material.color = org_colour;
    }
}
