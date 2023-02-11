using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private float move_speed;
    [SerializeField]
    private Renderer enemy_renderer;
    [SerializeField]
    enemyHealthText textScript;

    private void Start()
    {
        enemy_renderer.material.color = Color.blue;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * move_speed * Time.deltaTime);
    }

    /// <summary>
    /// Subtracts health from enemy and calls change colour
    /// </summary>
    public void damageEnemy()
    {
        //Change health
        _health -= 1;
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
        //Save original colour
        var org_colour = Color.blue;
        //Change colour to red
        enemy_renderer.material.color = Color.red;
        //Wait 1 second before changing back
        yield return new WaitForSeconds (0.5f);
        enemy_renderer.material.color = org_colour;
    }
}
